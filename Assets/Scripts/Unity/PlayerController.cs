using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Controls the player with the keyboard.
 * Handles interaction between the player and environment.
 */
public class PlayerController : MonoBehaviour {
	public float speed = 1.0f;

	private GameObject collidingWith = null;
	private HashSet<GameObject> sprites = new HashSet<GameObject>();
	Tooltip speechBubble = null;

	void Start() {
		GetAllNonPlayerSprites(GameObject.Find("Sprites").transform);
		speechBubble = UI.Get.makeSpeechBubble();
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
			if (SpriteOrderer.InFrontOf(this.gameObject, sprite)) {
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
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + speed * new Vector2(moveHorizontal, moveVertical) * Time.deltaTime);

		reorderSprites();
	}

	/*
	 * Respond to the interact button (E) if collidingWith a GameObject
	 */
	void LateUpdate() {
		if (collidingWith != null) {
			// interact with an interactable
			if (Input.GetKeyDown(KeyCode.E)) {
				Interactable obj = collidingWith.GetComponent<Interactable>();
				if (obj != null) {
					obj.interact(gameObject);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		collidingWith = other.gameObject;
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject != collidingWith) Debug.LogError("You seem to have overlapping colliders.");

		collidingWith = null;
	}
}
