using UnityEngine;
using System.Collections;

public class EnvironmentListener : MonoBehaviour {

	public delegate void EnvironmentChanged();
	public static event EnvironmentChanged onChanged;

	//When Environment is changed, update the environment
	void OnEnvironmentChanged() 
	{
		if(onChanged != null)
		{
			onChanged();
		}
		//foreach (resource in environment.ResourceObjects)
		//	unity.changeimage(resource)
	}
}
