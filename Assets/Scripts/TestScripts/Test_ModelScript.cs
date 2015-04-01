using UnityEngine;
using System.Collections;

public class Test_ModelScript : MonoBehaviour
{
    void OnMouseDown()
    {
		bool addedItem = Game.Get.Player.AddItem(new Item(2, "Some logs", Item.Type.CraftingMaterials));
		if (!addedItem) 
		{
			Debug.Log("Could not add item");
		}
    }

}
