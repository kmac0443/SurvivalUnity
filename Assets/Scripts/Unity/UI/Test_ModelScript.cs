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
			inv.AddItem(new Item(1, "Your trusty spellbook", Item.Type.Item0));
			inv.AddItem(new Item(3, "A scroll with your family history on it", Item.Type.Item1));
			inv.AddItem(new Item(2, "The Centaur's Axe", Item.Type.Item2));
			inv.AddItem(new Item(1, "Some creepy sword", Item.Type.Item3));
		}
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
