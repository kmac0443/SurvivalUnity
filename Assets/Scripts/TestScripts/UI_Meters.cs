using UnityEngine;
using System.Collections;

public class UI_Meters : MonoBehaviour {

    void OnEnable()
    {
		Inventory.StorageContainerChangedEvent += AdjustMeters;
    }

    void OnDisable()
    {
		Inventory.StorageContainerChangedEvent -= AdjustMeters;
    }

	void AdjustMeters(StorageContainer container)
	{
        Color color = new Color(Random.value, Random.value, Random.value);
        GetComponent<Renderer>().material.color = color;
        print("ColorChanged");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
