using UnityEngine;
using System.Collections;

public class ResourceObject : MonoBehaviour
{
    private StorageContainer storage;
    private bool itemsLeft;
    private int staminaRequired;
    private int timeRequired;

    public ResourceObject()
    {
        Active = false;
        Resources = new StorageContainer();
        StaminaRequired = 1;
        TimeRequired = 1;
    }

    public StorageContainer Resources
    {
        get { return this.storage; }
        set
        {
            if (null == value)
            {
                Active = false;
                return;
            }

            this.storage = value;
            if (storage.Capacity > 0)
            {
                Active = true;
            }
            else
            {
                Active = false;
            }
        }
    }

    public int StaminaRequired
    {
        get { return this.staminaRequired; }
        set { this.staminaRequired = value; }
    }

    public int TimeRequired
    {
        get { return this.timeRequired; }
        set { this.timeRequired = value; }
    }

    public bool Active
    {
        get { return this.itemsLeft; }
        set { this.itemsLeft = value; }
    }

    public Item OnGather()
    {
        if (!Active)
        {
            return null;
        }

        Item i = Resources.Items[0];
        Resources.RemoveItem(i);
        if (Resources.Capacity <= 0)
        {
            Active = false;
        }
        return i;
    }
    
    //////////////////////
    /// Unity Specific ///
    ////////////////////// 
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
