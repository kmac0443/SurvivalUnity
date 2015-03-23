using UnityEngine;
using System.Collections;

/**
 * A Unity wrapper for a StorageContainer.
 */
public class Container : Interactable {
	private StorageContainer container;

	void Start() {
		// TODO: temporary initialization
		container = new StorageContainer();
		container.AddItem(new Item(1, "TEST", Item.Type.Item0));
		container.AddItem(new Item(1, "TEST", Item.Type.Item1));
		container.AddItem(new Item(1, "TEST", Item.Type.Item2));
		container.AddItem(new Item(2, "TEST", Item.Type.Item3));
		container.AddItem(new Item(2, "TEST", Item.Type.Item0));
		container.MaxCapacity = 10;
	}

	public override void interact(GameObject actor)	{
		UI.Get.Storage.toggleShowing(container);
		UI.Get.refreshAll();
	}
}
