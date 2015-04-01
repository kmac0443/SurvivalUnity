using UnityEngine;
using System.Collections;

/*
 * A Unity object the player can interact with.
 */
public abstract class Interactable : MonoBehaviour {
	/*
	 * Have the player interact with the object.
	 * Returns true if the object is still interactable afterwards, false if not (probably destroyed)
	 */
	public abstract bool interact(GameObject actor);
}
