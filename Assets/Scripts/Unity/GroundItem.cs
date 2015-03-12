using UnityEngine;
using System.Collections;

/*
 * An item that can be picked up off the ground.
 */
public class GroundItem : Interactable {
	// TODO: What is an item? Is the type enough to create an item? (e.g. are descriptions, other things looked up?)
	public Item.Type itemType;

	public override void interact(GameObject actor) {
		// if (Game.Player.addToInventory(new Item(itemType))) {
		if (Test_ModelScript.inv.AddItem(new Item(0, "", itemType))) { //BAD!
			Destroy(gameObject);
		}
		else {
			Debug.LogError("Cannot pick up " + itemType + " on the ground.");
		}
	}

	void Start() {
		GetComponent<SpriteRenderer>().sprite = SpriteTable.Get(itemType);
	}
}
