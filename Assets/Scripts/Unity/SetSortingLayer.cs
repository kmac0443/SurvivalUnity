using UnityEngine;
using System.Collections;

/*
 * Set the sorting layer of objects that do not have a SpriteRenderer component.
 */
public class SetSortingLayer : MonoBehaviour {
	public string sortingLayer;
	public int sortingOrder = 0;

	// set on initialization
	void Start() {
		GetComponent<Renderer>().sortingLayerName = sortingLayer;
		GetComponent<Renderer>().sortingOrder = sortingOrder;
	}
}
