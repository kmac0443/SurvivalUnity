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
            //Because they listened for the event
        }

	}

    void OnEnable()
    {
        // The controller in turn Listened for an Event from the model
        Inventory.StorageContainerChangedEvent += InventoryChanged;
		//NPC.NPCChangedEvent += NPCChanged;
		//Vitals.VitalsChangedEvent += VitalsChanged;
		//ResourceObject.ResourceObjectsChangedEvent += ResourceObjectChanged;
		//Building.BuildingObjectChangedEvent += BuildingChanged;
		//Skill.SkillsChangedEvent += SkillsChanged;
		//Item.ItemChangedEvent += ItemChanged;
		//Attribute.AttributeChangedEvent += AttributesChanged;
		//Player.PlayerChangedEvent += PlayerChanged; ?????
    }

    void OnDisable()
    {
        // The controller in turn Listened for an Event from the model
        Inventory.StorageContainerChangedEvent -= InventoryChanged;
		//NPC.NPCChangedEvent -= NPCChanged;
		//Player.getVitals().VitalsChangedEvent -= VitalsChanged;
		//ResourceObject.ResourceObjectsChangedEvent -= ResourceObjectChanged;
		//Building.BuildingObjectChangedEvent -= BuildingChanged;
		//Skill.SkillsChangedEvent -= SkillsChanged;
		//Item.ItemChangedEvent -= ItemChanged;
		//Attribute.AttributeChangedEvent -= AttributesChanged;
		//Player.PlayerChangedEvent -= PlayerChanged; ?????
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void InventoryChanged(StorageContainer container)
    {
		print(container);
        print("Inventory Changed");
        //Since part of the model changed
        if (ModelChangedSoUpdateUIEvent != null)
        {
            ModelChangedSoUpdateUIEvent();
        }
    }

	void NPCChanged(NPC changedNPC)
	{

	}

	void VitalsChanged(Vitals changedVitals)
	{

	}

	void ResourceObjectChanged(ResourceObject changedObject)
	{

	}

	void BuildingChanged(Building changedBuilding)
	{

	}

	void SkillsChanged(Skill changedSkill)
	{

	}

	void ItemChanged(Item changedItem)
	{

	}

	void PlayerChanged(Player ChangedPlayer)
	{

	}
}