using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

/*
 * This represents a window that shows a storage container.
 * This will work for both the player's inventory and other storage containers he interacts with.
 */
public class StorageWindow : MonoBehaviour, IDropHandler {
	public GameObject itemPrefab;
	public int rows = 5;
	public int cols = 4;

	private float item_width;
	private float item_height;
	private RectTransform rectTransform;

	private StorageContainer currentContainer = null;
	private List<GameObject> items = new List<GameObject>();


	private void initialize() {
		gameObject.SetActive(true);
		items = new List<GameObject>();

		rectTransform = GetComponent<RectTransform>();
		item_width = rectTransform.rect.width / (cols + 1) * rectTransform.localScale.x;
		item_height = rectTransform.rect.height / (rows + 1) * rectTransform.localScale.y;
	}

	private GameObject spawn(Item item) {
		GameObject obj = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		obj.GetComponent<StorageItem>().setItem(this, item);
		obj.transform.SetParent(this.transform);
		return obj;
	}

	public Vector3 position(int x, int y) {
		return new Vector3(x * item_width + item_width, rectTransform.rect.height - (y * item_height) - item_height);
	}

	/*
	 *	This is called when the inventory or a storage container is opened.
	 */
	private void displayStorageContainer() {
		initialize();

		int i = 0;
		int j = 0;
		foreach (Item item in currentContainer.Items) {
			items.Add(spawn(item/*, position(i, j)*/));

			i += 1;
			if (i == cols) {
				i = 0;
				j += 1;
			}
		}
	}

	private void clear() {
		foreach (GameObject item in items) {
			Destroy(item);
		}

		items.Clear();
	}

	/*
	 * Close and reshow the window to reflect changes to the containers.
	 */
	public void refresh() {
		if (currentContainer != null) {
			clear();
			displayStorageContainer();
		}
		else {
			gameObject.SetActive(false);
		}
	}

	/*
	 * Show the container. If something else is showing, close it and show the new one.
	 */
	public void show(StorageContainer storage) {
		if (currentContainer != null) {
			if (currentContainer == storage) return; // do nothing if same
			else clear(); // close if it's something else
		}
		
		currentContainer = storage;
		displayStorageContainer();
	}

	/*
	 * Show the container if it is not showing.
	 * If it is showing, close it.
	 */
	public void toggleShowing(StorageContainer storage) {
		if (currentContainer != null) {
			if (currentContainer == storage) {
				close();
				return; // close if the same
			}
			else {
				clear();
			}
		}

		currentContainer = storage;
		displayStorageContainer();
	}

	/*
	 * Close the window.
	 */
	public void close() {
		clear();
		currentContainer = null;
		gameObject.SetActive(false);
	}

	public void OnDrop(PointerEventData eventData) {
		if (UI.Get.HeldItem == null) return;

		if (this != UI.Get.HeldItem.Parent) {
			if (currentContainer.AddItem(UI.Get.HeldItem.Item)) {
				UI.Get.HeldItem.Parent.currentContainer.RemoveItem(UI.Get.HeldItem.Item);
				UI.Get.HeldItem.Parent = this;
			}
			else {
				Debug.Log("Cannot add item to inventory.");
			}
		}

		UI.Get.HeldItem = null;
	}
}