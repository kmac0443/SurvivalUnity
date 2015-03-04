using UnityEngine;
using System.Collections;

public class GUIListener : MonoBehaviour {

	public delegate void GUIChanged();
	public static event GUIChanged onChanged;

	//When GUI is changed, update GUI on screen. //funnel all screen changes through here...not reall sure?
	void OnGUIChanged()//(GUIModel gui)
	{
		if(onChanged != null)
		{
			onChanged();
		}
		//Currentgui.visable = false
			//Newgui.visible = true
	}

}
