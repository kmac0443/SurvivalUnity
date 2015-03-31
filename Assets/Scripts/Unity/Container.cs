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
		container.AddItem(new Item(1, "A functional water filter.", Item.Type.WaterFilter));
		container.AddItem(new Item(1, "Some logs", Item.Type.CraftingMaterials));
		container.MaxCapacity = 10;
	}

	public override void interact(GameObject actor)	{
		UI.Get.Storage.toggleShowing(container);
		UI.Get.refreshAll();
	}
}
