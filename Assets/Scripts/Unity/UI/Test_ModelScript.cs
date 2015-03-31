using UnityEngine;
using System.Collections;

public class Test_ModelScript : MonoBehaviour
{
	public static Inventory inv;
	Item testingItem;

    void Start()
    {
        inv = new Inventory();
		inv.AddItem(new Item(3, "Your trusy canteen", Item.Type.Canteen));
		inv.AddItem(new Item(1, "Your dad's lucky dagger", Item.Type.Dagger));

    }

    void OnMouseDown()
    {
		bool addedItem = inv.AddItem(new Item(2, "Some logs", Item.Type.CraftingMaterials));
		if (!addedItem) 
		{
			Debug.Log("Could not add item");
		}
    }

}
