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
	void Awake() {
		Inventory.StorageContainerChangedEvent += InventoryChanged;

		UI.initialize(
			inventoryWindowObject.GetComponent<StorageWindow>(),
			containerWindowObject.GetComponent<StorageWindow>()
		);
	}

	void Start() {
		//DontDestroyOnLoad(gameObject);
	}

	public void showInventory() {
		UI.Get.Inventory.toggleShowing(Game.Get.Player.Inventory);
		UI.Get.refreshAll();
	}

	/*
	 *	This should be the only function that checks for keypresses, at least for now (other than player movement in FixedUpdate).
	 *  The same keys should not be checked in multiple places to avoid reopening dialogs and stuff.
	 */
	void Update() {
		if (Input.GetKeyDown(KeyCode.I)) {
			showInventory();
		}
		else if (Input.GetKeyDown(KeyCode.E)) {
			if (UI.Get.modalShowing()) UI.Get.closeAll();
			else Game.Get.PlayerController.interact();
		}
		else if (Input.GetKeyDown(KeyCode.Escape)) {
			UI.Get.closeAll();
		}

		// TODO: this shouldn't really be here, but whatever
		// change the levels of food or wate
		if (Input.GetKey(KeyCode.Minus)) {
			Game.Get.Player.vitals.Decrease(MeterType.Food, 1);
		}
		else if (Input.GetKey(KeyCode.Equals)) {
			Game.Get.Player.vitals.Increase(MeterType.Food, 1);
		}
		if (Input.GetKey(KeyCode.KeypadMinus)) {
			Game.Get.Player.vitals.Decrease(MeterType.Water, 1);
		}
		else if (Input.GetKey(KeyCode.KeypadPlus)) {
			Game.Get.Player.vitals.Increase(MeterType.Water, 1);
		}
	}

	void InventoryChanged(StorageContainer container) {
		UI.Get.refreshAll ();
	}
}
