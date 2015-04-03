using UnityEngine;
using System.Collections;

/*
 * An item that can be picked up off the ground.
 */
public class GroundItem : Interactable {
	public Item item;

	public int girth;
	public string description;
	public Type type;

	public override bool interact(GameObject actor) {
		if (Game.Get.Player.AddItem(item)) {
			Game.Get.PlayerController.say("Wow! I found " + item.Label);
			Destroy(gameObject);
			return false;
		}
		else {
			Debug.Log("Cannot pick up " + item.ItemType + " on the ground.");
			return true;
		}
	}

	/*
	 * Construct a new GroundItem
	 */
	public static GameObject create(Item item, Vector3 position, string name = "Ground Item", Transform parent = null) {
		GameObject newItem = Instantiate(Resources.Load("GroundItem"), position, Quaternion.identity) as GameObject;
		newItem.GetComponent<GroundItem>().setItem(item);

		if (parent != null) newItem.transform.SetParent(parent);

		return newItem;
	}

	public void setItem(Item item) {
		this.item = item;
		GetComponent<SpriteRenderer>().sprite = SpriteTable.Get(item.ItemType);
	}

	void Start() {
		if (item == null) {
			item = new Item(girth, description, type);
		}
		GetComponent<SpriteRenderer>().sprite = SpriteTable.Get(item.ItemType);
	}

	void OnValidate() {
		Start();
	}
}
