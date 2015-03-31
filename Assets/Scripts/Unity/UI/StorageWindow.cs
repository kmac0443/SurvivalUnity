using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

/*
 * This represents a window that shows a storage container.
 * This will work for both the player's inventory and other storage containers he interacts with.
 */
public class StorageWindow : MonoBehaviour, IDropHandler {
	public GameObject itemPrefab;
	public GameObject slotPrefab;
	public string windowName;
	public Vector2 cellSize = new Vector2(48, 48);
	
	private StorageContainer currentContainer = null;
	private List<StorageItem> items = new List<StorageItem>();
	private List<GameObject> slots = new List<GameObject>();

	private GameObject grid;
	private GameObject title;

	private void initialize() {
		gameObject.SetActive(true);
		items = new List<StorageItem>();

		if (grid != null) {
			Destroy(grid);
			Destroy(title);
		}

		// create the title
		title = new GameObject("Storage Window Title", new System.Type[] {typeof(Text)});
		title.transform.SetParent(this.transform);

		title.GetComponent<Text>().text = windowName;
		title.GetComponent<Text>().font = UI.Get.DefaultFont;
		title.GetComponent<Text>().fontSize = 16;
		title.GetComponent<Text>().color = Color.black;
		title.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		title.GetComponent<Text>().supportRichText = true;

		// create the grid of itmes
		grid = new GameObject("Storage Window Grid", new System.Type[]{typeof(GridLayoutGroup)});
		grid.transform.SetParent(this.transform);

		grid.GetComponent<GridLayoutGroup>().cellSize = cellSize;
	}

	private StorageItem spawn(Item item) {
		StorageItem obj = (Instantiate(itemPrefab, Vector3.zero, Quaternion.identity) as GameObject).GetComponent<StorageItem>();
		obj.setItem(this, item);

		return obj;
	}

	private void addItem(Item item) {
		StorageItem obj = spawn(item);
		items.Add(obj);
		items.AddRange(obj.Girth);
	}

	private void addSlots() {
		slots.Clear();

		for (int n = 0; n < currentContainer.MaxCapacity; ++n) {
			GameObject slot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			slot.transform.SetParent(grid.transform);
			slots.Add(slot);
		}
	}

	private void placeInSlots() {
		addSlots();

		for (int i = 0; i < items.Count; ++i) {
			items[i].gameObject.transform.SetParent(slots[i].transform);
		}
	}

	/*
	 *	This is called when the inventory or a storage container is opened.
	 */
	private void displayStorageContainer() {
		initialize();

		foreach (Item item in currentContainer.Items) {
			addItem(item);
		}

		placeInSlots();
	}

	private void clear() {
		foreach (StorageItem item in items) {
			Destroy(item.gameObject);
		}

		items.Clear();

		foreach (GameObject obj in slots) {
			Destroy(obj);
		}
		
		slots.Clear();
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
		if (!UI.Get.holdingItem()) return;

		if (this != UI.Get.HeldItem.Parent) {
			if (currentContainer.AddItem(UI.Get.HeldItem.Item)) {
				UI.Get.HeldItem.Parent.currentContainer.RemoveItem(UI.Get.HeldItem.Item);
			}
			else {
				Debug.Log("Cannot add item to inventory.");
			}
		}

		UI.Get.refreshAll();
	}

	void OnDestroy() {
		if (grid != null) {
			Destroy(grid);
			Destroy(title);
		}

		grid = null;
		title = null;
	}

	public StorageContainer StorageContainer {
		get { return currentContainer; }
	}
}