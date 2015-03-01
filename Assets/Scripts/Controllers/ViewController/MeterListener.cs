using UnityEngine;
using System.Collections;
using Model.ModelObjects.Person;
using Model.ModelObjects.MeterManagment;

public class MeterListener : MonoBehaviour {

	public delegate void metersChanged(Player player); //maybe better to pass vitals object only
	public static event metersChanged onChanged;

	//When Meter changed, update Meters on screen.
	void OnMeterChanged(Player player) //maybe better to pass vitals object only
	{
		//Update meter gui
		if(onChanged != null)
		{
			onChanged(player);
		}
	}
}
