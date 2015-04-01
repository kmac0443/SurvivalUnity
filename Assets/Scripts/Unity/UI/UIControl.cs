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
		Inventory.StorageContainerChangedEvent += InventoryChanged;
		UI.initialize(
			inventoryWindowObject.GetComponent<StorageWindow>(),
			containerWindowObject.GetComponent<StorageWindow>()
		);
	}

	/*
	 *	This should be the only function that checks for keypresses, at least for now (other than player movement in FixedUpdate).
	 *  The same keys should not be checked in multiple places to avoid reopening dialogs and stuff.
	 */
	void Update() {
		if (Input.GetKeyDown(KeyCode.I)) {
			UI.Get.Inventory.toggleShowing(Game.Get.Player.Inventory);
			UI.Get.refreshAll();
		}
		else if (Input.GetKeyDown(KeyCode.E)) {
			if (UI.Get.modalShowing()) UI.Get.closeAll();
			else Game.Get.PlayerController.interact();
		}
		else if (Input.GetKeyDown(KeyCode.Escape)) {
			UI.Get.closeAll();
		}
	}

	void InventoryChanged(StorageContainer container) {
		UI.Get.refreshAll ();
	}
}
