using UnityEngine;
using System.Collections;

public class Test_ModelScript : MonoBehaviour
{
	public static Inventory inv;
	Item testingItem;

    void Start()
    {
        inv = new Inventory();
		inv.AddItem(new Item(10, "hey", Item.Type.Item0));
		inv.AddItem(new Item(10, "hey", Item.Type.Item1));
		inv.AddItem(new Item(10, "hey", Item.Type.Item2));
		inv.AddItem(new Item(10, "hey", Item.Type.Item3));
    }

    void OnMouseDown()
    {
		bool addedItem = inv.AddItem(new Item(10, "hey", Item.Type.Item0));
		if (!addedItem) 
		{
			Debug.Log("Could not add item");
		}
    }

}
