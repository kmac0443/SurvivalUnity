using UnityEngine;
using System.Collections;

/*
 * Keep the window objects for the UI here.
 */
public class UI {
	private static UI instance = null;

	private UI(StorageWindow inventory, StorageWindow container) {
		inventoryWindow = inventory;
		storageWindow = container;
	}
	
	private StorageWindow inventoryWindow;
	private StorageWindow storageWindow;
	private StorageItem currentItem = null;

	public static void initialize(StorageWindow inventory, StorageWindow container) {
		instance = new UI(inventory, container);
	}

	public static UI Get {
		get { 
			if (instance == null) throw new System.Exception("You failed to initialize the UIManager!");

			return instance;
		}
	}

	public void closeAll() {
		inventoryWindow.close();
		storageWindow.close();
	}

	public void refreshAll() {
		inventoryWindow.refresh();
		storageWindow.refresh();
	}

	public StorageWindow Inventory {
		get { return inventoryWindow; }
	}

	public StorageWindow Storage {
		get { return storageWindow; }
	}

	public StorageItem HeldItem {
		get { return currentItem; }
		set { currentItem = value; }
	}
}
