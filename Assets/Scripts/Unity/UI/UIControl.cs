using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {
	public GameObject inventoryWindowObject;
	private StorageWindow inventoryWindow;
	
	// Use this for initialization
	void Start () {
		inventoryWindow = inventoryWindowObject.GetComponent<StorageWindow>();

		if (inventoryWindow == null) {
			Debug.LogError("InventoryWindow not found!");
		}
	}

	void LateUpdate() {
		if (Input.GetKeyDown(KeyCode.I)) {
			// TODO: remove this test code -- this should be the player's inventory
			StorageContainer test_inv = new StorageContainer();
			
			for (int i = 0; i < 5; ++i) {
				test_inv.AddItem(new Item(0, "hey", Item.Type.Item0));
				test_inv.AddItem(new Item(0, "hey", Item.Type.Item1));
				test_inv.AddItem(new Item(0, "hey", Item.Type.Item2));
				test_inv.AddItem(new Item(0, "hey", Item.Type.Item3));
			}

			inventoryWindow.displayStorageContainer(test_inv);
		}
	}
}
