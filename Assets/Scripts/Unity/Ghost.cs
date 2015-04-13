	using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
	public SpriteRenderer displaySprite;

	void OnValidate() {
		Update();
	}

	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer>().sprite = displaySprite.sprite;
	}
}
