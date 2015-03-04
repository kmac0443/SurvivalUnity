using UnityEngine;
using System.Collections;

public class SceneListener : MonoBehaviour {

	public delegate void sceneChanged();
	public static event sceneChanged onChanged;

	//When Scene is changed, update scene.
	void OnSceneChanged()//(SceneModel scene) 
	{
		if(onChanged != null)
		{
			onChanged();
		}
		//Unity.changescene(scene.currentscene)
	}
}
