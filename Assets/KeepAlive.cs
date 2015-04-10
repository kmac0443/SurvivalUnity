using UnityEngine;
using System.Collections.Generic;

public class KeepAlive : MonoBehaviour {
	static HashSet<string> exists = new HashSet<string>();

	public string uniqueName = null;

	/* Delete the object if it shouldn't exist */	
	void Awake() {
		if (exists.Contains(uniqueName)) {
			Destroy(this.gameObject);
		}
		else {
			DontDestroyOnLoad(gameObject);
			exists.Add(uniqueName);
		}
	}

	/* Set a default name */
	void OnValidate() {
		if (uniqueName == null) uniqueName = gameObject.name;
	}
}
