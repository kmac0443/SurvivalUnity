using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour
{
    protected Inventory inventory;

    public Person()
    {
        this.inventory = new Inventory();
    }

    public bool AddItem(Item item)
    {
        bool success = this.inventory.AddItem(item);
        if (success)
        {
            //Raise event
        }
        return success;
    }

    public bool RemoveItem(Item item)
    {
        bool success = this.inventory.RemoveItem(item);
        if (success)
        {
            //Raise event
        }
        return success;
    }

    public virtual int DealDamage()
    {
        return 0;
    }

    public virtual void ReceiveDamage(int damage)
    {
        return;
    }

    public virtual void OnTime()
    {
        //Console.WriteLine("OnTime: I'm a Person");
    }

    public virtual void OnUpdate()
    {
        //Console.WriteLine("OnUpdate: I'm a Person");
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
