using UnityEngine;
using System.Collections;

/*
 * Controls the player with the keyboard.
 * Handles interaction between the player and environment.
 */
public class PlayerController : MonoBehaviour {
	public float speed = 1.0f;

	private GameObject collidingWith = null;

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		rigidbody2D.MovePosition(rigidbody2D.position + speed * new Vector2(moveHorizontal, moveVertical) * Time.deltaTime);
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
