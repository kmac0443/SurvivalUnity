using UnityEngine;
using System.Collections;

/*
 * An item that can be picked up off the ground.
 */
public class GroundItem : Interactable {
	// TODO: What is an item? Is the type enough to create an item? (e.g. are descriptions, other things looked up?)
	public Item item;

	public override void interact(GameObject actor) {
		if (Test_ModelScript.inv.AddItem(item)) {
			Destroy(gameObject);
		}
		else {
			Debug.LogError("Cannot pick up " + item.ItemType + " on the ground.");
		}
	}

	public void setItem(Item item) {
		this.item = item;
		GetComponent<SpriteRenderer>().sprite = SpriteTable.Get(item.ItemType);
	}

	void Start() {
		if (item == null) {
			item = new Item(2, "Some logs", Item.Type.CraftingMaterials);
		}
		GetComponent<SpriteRenderer>().sprite = SpriteTable.Get(item.ItemType);
	}
}
