using UnityEngine;
using System.Collections;
using Model.ModelObjects.Person;
using Model.ModelObjects.ItemManagement;

public class PlayerListener : MonoBehaviour { /*this would be synonymous with character listener on wiki
I thought this would be less ambiguous because we also have an NPC Listener*/

	public delegate void PlayerChanged();
	public static event PlayerChanged onChanged;

	//When Character is changed, update character/inventory on screen.
	void OnPlayerChanged(Player player)
	{	
		if(onChanged != null)
		{
			onChanged();
		}
		//Change player location?
		//Change player iventory?
		//Change player which way looking?
	}
		
	/*void OnInventoryChanged(Inventory inventory) //maybe separate for inventory...
	{
		//Update gui with inventory and any item being held
	}*/

}
