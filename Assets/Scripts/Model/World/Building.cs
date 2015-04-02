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

}
