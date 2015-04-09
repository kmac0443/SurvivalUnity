using UnityEngine;
using System.Collections;

public class Portal : Interactable {
	public string goToScene;

	void Awake() {
		if (goToScene == null) {
			Debug.LogError("Portal " + gameObject.name + " has no destination scene!");
		}
	}

	public override bool interact(GameObject actor) {
		Application.LoadLevel(goToScene);
		return false;
	}
}
