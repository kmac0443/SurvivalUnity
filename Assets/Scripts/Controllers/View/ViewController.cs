using UnityEngine;
using System;

public class ViewController : MonoBehaviour
{
    // ONLY JOB is to tell UI to update
    public delegate void UIDelegate();
    public static event UIDelegate ModelChangedSoUpdateUIEvent;

	// Use this for initialization
	void Start () {
        
        // So you can see it in action - On Start Trigger event
        if (ModelChangedSoUpdateUIEvent != null)
        {
            ModelChangedSoUpdateUIEvent();
            //This in turn calls UI_Meters -> AdjustMeters
            //Because they listend for the event
        }

	}

    void OnEnable()
    {
        // The controller in turn Listened for an Event from the model
        Inventory.StorageContainerChangedSoTellViewControllerEvent += InventoryChanged;
		//NPC.NPCChangedEvent += NPCChanged;
		//Vitals.VitalsChangedEvent += VitalsChanged;
		//ResourceObject.ResourceObjectsChangedEvent += ResourceObjectChanged;
		//Building.BuildingObjectChangedEvent += BuildingChanged;
		//Skill.SkillsChangedEvent += SkillsChanged;
		//Item.ItemChangedEvent += ItemChanged;
    }

    void OnDisable()
    {
        // The controller in turn Listened for an Event from the model
        Inventory.StorageContainerChangedSoTellViewControllerEvent -= InventoryChanged;
		//NPC.NPCChangedEvent -= NPCChanged;
		//Player.getVitals().VitalsChangedEvent -= VitalsChanged;
		//ResourceObject.ResourceObjectsChangedEvent -= ResourceObjectChanged;
		//Building.BuildingObjectChangedEvent -= BuildingChanged;
		//Skill.SkillsChangedEvent -= SkillsChanged;
		//Item.ItemChangedEvent -= ItemChanged;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void InventoryChanged()
    {
        Console.WriteLine("Inventory Changed");
        //Since part of the model changed
        if (ModelChangedSoUpdateUIEvent != null)
        {
            ModelChangedSoUpdateUIEvent();
        }
    }

	void NPCChanged()
	{

	}

	void VitalsChanged()
	{

	}

	void ResourceObjectChanged()
	{

	}

	void BuildingChanged()
	{

	}

	void SkillsChanged()
	{

	}

	void ItemChanged()
	{

	}
}