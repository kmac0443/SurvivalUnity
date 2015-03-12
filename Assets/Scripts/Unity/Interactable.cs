using UnityEngine;
using System.Collections;

/*
 * A Unity object the player can interact with.
 */
public abstract class Interactable : MonoBehaviour {
	public abstract void interact(GameObject actor);
}
