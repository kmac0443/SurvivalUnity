using UnityEngine;
using System.Collections;

/*
 * An item that can be picked up off the ground.
 */
public class ResourceObjectController : Interactable {
	public Type requiredItem;
	public ResourceObject myObject;
	
	public override bool interact(GameObject actor) {
		Debug.Log ("Interacted with a resource");
		/**
		 * if(player.inventory.hasEquipped(requiredItem) {
		 * 		if(Game.Get.Player.stamia >= myObject.requiredStamina) {
		 * 			startCorutine("ResourceInteract");
		 * 		}
		 * 		else {
		 * 			Game.Get.PlayerController.say("I'm too tired to do that");
		 *		}
		 * }
		 * else {
		 * 		player.say("I don't have the right item equipped");
		 * }
		 * */
		return true;
	}
	
	private IEnumerator ResourceInteract() {
		Time.timeScale = 0;
		yield return new WaitForSeconds(1); //TODO Wait for myObject.timeRequied
		//slowly decrement bar;
		Time.timeScale = 1;
		Item resourceItem = myObject.OnGather ();
		if (!Game.Get.Player.AddItem(myObject.OnGather())) {
			//dropItem(resourceItem);
		}
		//player.decrementStamina (myObject.requiredStamina);
		//time.change(myObject.timeRequired);
		if (myObject.Active == false) {
			//changeSprite
		}
	}
	
	void Start() {
	}
}
