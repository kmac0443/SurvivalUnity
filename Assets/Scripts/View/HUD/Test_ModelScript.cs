using UnityEngine;
using System.Collections;

public class Test_ModelScript : MonoBehaviour
{
	public static Inventory inv;
	Item testingItem;

    void Start()
    {
        inv = new Inventory();
		for (int i = 0; i < 5; ++i) {
			inv.AddItem(new Item(0, "hey", Item.Type.Item0));
			inv.AddItem(new Item(0, "hey", Item.Type.Item1));
			inv.AddItem(new Item(0, "hey", Item.Type.Item2));
			inv.AddItem(new Item(0, "hey", Item.Type.Item3));
		}
    }

    void OnMouseDown()
    {
		print("Adding item to inventory");
		print (inv.Items.Count + " num of items in inventory");
		foreach (Item myItem in inv.Items)
		{
			print ("I'm Item: " + myItem.ID);
		}
		testingItem = new Item();
		print("My Item is " + testingItem + " but has an ID of " + testingItem.ID);
		inv.AddItem(testingItem);
    }

}
