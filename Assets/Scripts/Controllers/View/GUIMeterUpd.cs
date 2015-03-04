using UnityEngine;
using System.Collections;
using Model.ModelObjects.Person;

public class GUIMeterUpd : MonoBehaviour {

	public void onEnable()
	{
		MeterListener.onChanged += updateMeterRepresentation;
	}

	void onDisable()
	{
		MeterListener.onChanged -= updateMeterRepresentation;
	}

	void updateMeterRepresentation(Player player)
	{
		print ("would update meters here");
	}
}
