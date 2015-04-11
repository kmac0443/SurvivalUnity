using UnityEngine;
using System.Collections;

/* Water you can drink */
public class Water : Interactable {
	public override bool interact(GameObject actor)	{
		if (Game.Get.Player.Inventory.ContainsType(Type.WaterFilter, Type.MouthFilter)) {
			Game.Get.Player.vitals.Increase(MeterType.Water, 10);
			Game.Get.Player.vitals.Increase(MeterType.Ash, 1);

			Game.Get.PlayerController.say("You use your filter to drink some water.");
		}
		else {
			Game.Get.PlayerController.say("You don't have anything to filter the water with!");
		}

		return true; // water will still be there
	}
}
