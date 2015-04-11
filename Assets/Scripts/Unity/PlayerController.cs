using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Controls the player with the keyboard.
 * Handles interaction between the player and environment.
 */
public class PlayerController : MonoBehaviour {
	public float speed = 2.0f;

	private LinkedList<GameObject> collidingWith = new LinkedList<GameObject>();
	private HashSet<GameObject> sprites = new HashSet<GameObject>();
	Tooltip speechBubble = null;

	void Start() {
		GameObject spritesRoot = GameObject.Find("Sprites");
		if (spritesRoot != null) GetAllNonPlayerSprites(spritesRoot.transform);
		else Debug.LogWarning("No GameObject \"Sprites\" exists."); 

		speechBubble = UI.Get.makeSpeechBubble();

		if (Game.Get.playerHasStartingPosition()) {
			this.transform.position = Game.Get.playerStartingPosition();
		}

		// set this as the Player object in the Game singleton
		Game.Get.PlayerController = this;
	}

	/* Get all of the children with renderers */
	private void GetAllNonPlayerSprites(Transform parent) {
		foreach (Transform sprite in parent) {
			if (sprite.GetComponent<Renderer>() != null && sprite.GetComponent<Collider2D>() != null
			      && sprite.GetComponent<Renderer>().sortingLayerName == "Character" && (sprite != this.transform)) {
				sprites.Add(sprite.gameObject);
			}

			GetAllNonPlayerSprites(sprite);
		}
	}

	/* Rearrange the rendering order of the sprites */
	private void reorderSprites() {
		// this is O(n) in the number of sprites, which shouldn't be a problem
		foreach (GameObject sprite in sprites) {
			if (sprite == null) {
				continue;
			}
			else if (SpriteOrderer.InFrontOf(this.gameObject, sprite)) {
				if (sprite.GetComponent<Renderer>().sortingOrder > GetComponent<Renderer>().sortingOrder) {
					// move the sprite behind you
					sprite.GetComponent<Renderer>().sortingOrder -= GetComponent<Renderer>().sortingOrder+1;
				}
			}
			else if (sprite.GetComponent<Renderer>().sortingOrder < GetComponent<Renderer>().sortingOrder) {
				// move the sprite in front of you
				sprite.GetComponent<Renderer>().sortingOrder += GetComponent<Renderer>().sortingOrder+1;
			}
		}

		sprites.Remove(null);
	}

	private int updateCalls = 0;
	public int meterChangeDelay = 50;

	private void updateMeters(bool moving) {
		updateCalls += 1;

		const int amount = 1;

		if (updateCalls > meterChangeDelay) {
			updateCalls = 0;

			if (moving) {
				Game.Get.Player.vitals.Decrease(MeterType.Food, amount);
				Game.Get.Player.vitals.Decrease(MeterType.Water, 2*amount);
				Game.Get.Player.vitals.Decrease(MeterType.Stamina, amount);
			}
			else {
				Game.Get.Player.vitals.Increase(MeterType.Stamina, amount);
			}

			if (Application.loadedLevelName == "Essen") {
				Game.Get.Player.vitals.Increase(MeterType.Ash, amount);
			}
			else {
				Game.Get.Player.vitals.Decrease(MeterType.Ash, amount);
			}
		}
	}

	void FixedUpdate() {
		// do not allow character actions if a modal dialog is shown
		if (UI.Get.modalShowing()) return;

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		if (moveHorizontal != 0 || moveVertical != 0) {
			GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + speed * new Vector2(moveHorizontal, moveVertical) * Time.deltaTime);

			updateMeters(true);
		}
		else {
			updateMeters(false);
		}

		reorderSprites();
	}

	/*
	 * Respond to the interact button (E) if collidingWith a GameObject
	 */
	public void interact() {
		// do not allow character actions if a modal dialog is shown
		if (collidingWith.Count > 0) {
			// interact with an interactable
			Interactable obj = collidingWith.First.Value.GetComponent<Interactable>();

			if (obj != null) {
				// if still exists, move it to the back of the queue to cycle through currently colliding items
				if (obj.interact(gameObject)) {
					var first = collidingWith.First;

					collidingWith.RemoveFirst();
					collidingWith.AddLast(first);
				}
				else {
					collidingWith.RemoveFirst();
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		collidingWith.AddLast(other.gameObject);
	}

	void OnTriggerExit2D(Collider2D other) {
		collidingWith.Remove(other.gameObject);
	}

	/*
	 * Have the player display a message in his speech bubble.
	 * If seconds is negative, the message is displayed until the function is called again.
	 */
	public void say(string message, int seconds = 2) {
		speechBubble.displayBubble(gameObject, message);

		if (seconds >= 0) speechBubble.fadeOutAndClose(seconds);
	}
}
