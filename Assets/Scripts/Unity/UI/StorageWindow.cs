using UnityEngine;
using System.Collections.Generic;

/*
 * This represents a window that shows a storage container.
 * This will work for both the player's inventory and other storage containers he interacts with.
 */
public class StorageWindow : MonoBehaviour {
	public int rows = 5;
	public int cols = 4;

	private float item_width;
	private float item_height;

	// TODO: this should be done dynamically or based off of the InventoryItem's size
	private float left_margin = 100.0f;
	private float top_margin = 50.0f;

	private void initialize() {
		gameObject.SetActive(true);
		items = new List<GameObject>();

		RectTransform rectTransform = GetComponent<RectTransform>();
		item_width = rectTransform.rect.width / cols * rectTransform.localScale.x;
		item_height = rectTransform.rect.height / rows * rectTransform.localScale.x;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			close();
		}
	}

	private List<GameObject> items;

	public GameObject prefab;
	
	private GameObject spawn(Item item, Vector3 location) {
		GameObject obj = Instantiate(prefab, location, Quaternion.identity) as GameObject;
		obj.GetComponent<StorageItem>().setItem(item);
		obj.transform.SetParent(this.transform);
		return obj;
	}

	/*
	 *	This is called when the inventory or a storage container is opened.
	 */
	public void displayStorageContainer(StorageContainer storage) {
		if (gameObject.activeSelf) {
			Debug.Log("This storage window is already open.");
			return;
		}

		initialize();

		int i = 0;
		int j = 0;
		foreach (Item item in storage.Items) {
			items.Add(spawn(item, new Vector3(left_margin + i * item_width, top_margin + j * item_height)));

			i += 1;
			if (i == cols) {
				i = 0;
				j += 1;
			}
		}
	}

	public void close() {
		foreach (GameObject item in items) {
			Destroy(item);
		}

		items.Clear();

		gameObject.SetActive(false);
	}
}