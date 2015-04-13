using UnityEngine;
using System.Collections;

/**
 * A Unity wrapper for a StorageContainer.
 */
public class Container : Interactable {
	private StorageContainer container;

	private static System.Random rand = new System.Random(1001); // fixed seed
	public int MAX_ITEMS = 5;

	private static Item[] possibleItems = {
		new Item(1, "canteen", Type.Canteen),
		new Item(2, "fishing pole", Type.FishingPole),
		new Item(2, "axe", Type.Axe),
		new Item(1, "dagger", Type.Dagger),
		new Item(4, "logs", Type.CraftingMaterials),
		new Item(2, "pickaxe", Type.Pickaxe),
		new Item(1, "small water filter", Type.MouthFilter),
		new Item(3, "shovel", Type.Shovel),
		new Item(1, "water filter", Type.WaterFilter),
	};
	
	void Start() {
		// TODO: temporary initialization
		container = new StorageContainer();

		int numberOfItems = rand.Next() % MAX_ITEMS;

		if (numberOfItems == 0) {
			container.MaxCapacity = rand.Next() % 10 + 3;
		}
		else {
			container.MaxCapacity = 0;

			for (int i = 0; i < numberOfItems; ++i) {
				Item template = possibleItems[rand.Next() % possibleItems.Length];
				Item item = new Item(template.Girth, template.Label, template.ItemType);

				container.MaxCapacity += item.Girth;
				container.AddItem(item);
			}

			container.MaxCapacity += rand.Next() % 10; // add some extra space, maybe
		}

		//container.AddItem(new Item(1, "water filter", Type.WaterFilter));
		//container.AddItem(new Item(3, "logs", Type.CraftingMaterials));
		//container.MaxCapacity = 10;
	}

	public override bool interact(GameObject actor)	{
		UI.Get.Storage.toggleShowing(container);
		UI.Get.refreshAll();

		return true; // always exists after interacting
	}
}
