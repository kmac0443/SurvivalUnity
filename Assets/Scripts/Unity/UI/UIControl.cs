using UnityEngine;
using System.Collections;

/*
 * Control the UI.
 * Open and close things with the keyboard.
 */
public class UIControl : MonoBehaviour {
	public GameObject inventoryWindowObject;
	public GameObject containerWindowObject;
	
	// Use this for initialization
	void Start () {
		UI.initialize(
			inventoryWindowObject.GetComponent<StorageWindow>(),
			containerWindowObject.GetComponent<StorageWindow>()
		);
	}

	void LateUpdate() {
		if (Input.GetKeyDown(KeyCode.I)) {
			UI.Get.Inventory.toggleShowing(Test_ModelScript.inv);
			UI.Get.refreshAll();
		}
		else if (Input.GetKeyDown(KeyCode.Escape)) {
			UI.Get.closeAll();
		}
	}
}
