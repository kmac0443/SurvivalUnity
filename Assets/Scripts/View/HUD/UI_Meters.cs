using UnityEngine;
using System.Collections;

public class UI_Meters : MonoBehaviour {

    void OnEnable()
    {
        ViewController.ModelChangedSoUpdateUIEvent += AdjustMeters;
    }

    void OnDisable()
    {
        ViewController.ModelChangedSoUpdateUIEvent -= AdjustMeters;
    }

    void AdjustMeters()
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
