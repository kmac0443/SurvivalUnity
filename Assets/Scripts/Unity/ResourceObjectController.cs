using UnityEngine;
using System.Collections;

/*
 * An item that can be picked up off the ground.
 */
public class ResourceObjectController : Interactable {
	public Type requiredItem;
	public ResourceObject myObject;
	private Player player;
	private PlayerController playerController;
	
	public override bool interact(GameObject actor) {
		Debug.Log ("Interacted with a resource");
		/**
		 * if(player.Inventory.hasEquipped(requiredItem) {
		 * 		if(player.stamia >= myObject.requiredStamina) {
		 * 			startCorutine("ResourceInteract");
		 * 		}
		 * 		else {
		 * 			playerController.speechBubble.displayBubble(player, "I'm too tired to do this.");
					playerController.speechBubble.fadeOutAndClose(3);
		 *		}
		 * }
		 * else {
		 * 		playerController.speechBubble.displayBubble(player, "I don't have the right item equipped.");
					playerController.speechBubble.fadeOutAndClose(3);
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
		if (!player.AddItem(myObject.OnGather())) {
			//dropItem(resourceItem);
		}
		//player.decrementStamina (myObject.requiredStamina);
		//time.change(myObject.timeRequired);
		if (myObject.Active == false) {
			//changeSprite
		}
	}
	
	void Start() {
		player = Game.Get.Player;
		playerController = Game.Get.PlayerController;
	}
}
