using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    private StorageContainer storage;

    public Building()
    {
        Storage = new StorageContainer();
    }

    public StorageContainer Storage
    {
        get { return this.storage; }
        set { this.storage = value; }
    }

    //////////////////////
    /// Unity Specific ///
    ////////////////////// 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
