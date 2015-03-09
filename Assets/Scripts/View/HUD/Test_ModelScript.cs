using UnityEngine;
using System.Collections;

public class Test_ModelScript : MonoBehaviour
{
    Inventory inv;
	Item testingItem;

    void Start()
    {
         inv = new Inventory();
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
