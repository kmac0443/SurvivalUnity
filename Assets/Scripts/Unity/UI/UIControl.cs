using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {
	public GameObject inventoryWindowObject;
	private StorageWindow inventoryWindow;
	public StorageContainer test_inv;
	
	// Use this for initialization
	void Start () {
		inventoryWindow = inventoryWindowObject.GetComponent<StorageWindow>();
		test_inv = new StorageContainer();

		if (inventoryWindow == null) {
			Debug.LogError("InventoryWindow not found!");
		}
	}

	void LateUpdate() {
		if (Input.GetKeyDown(KeyCode.I)) {
			if(inventoryWindow.gameObject.activeSelf)
			{
				inventoryWindow.close();
			}
			else
			{
				inventoryWindow.displayStorageContainer(Test_ModelScript.inv);
			}
		}
	}
}
