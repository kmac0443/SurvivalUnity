using UnityEngine;
using System.Collections;

public class NPCListener : MonoBehaviour {

	public delegate void NPCChanged();
	public static event NPCChanged onChanged;

	//When NPC is changed, update NPCs on screen.
	void OnNPCChanged()//(NPCList npcs)
	{
		if(onChanged != null)
		{
			onChanged();
		}
		/*foreach(NPC in npcs)
		{
			update location //probably other than location. Unity will likely handle location...not sure
		}*/
	}
}
