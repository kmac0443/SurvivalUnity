using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour, IDamageAffecting
{
    private Guid uniqueID;
    private int inventorySpaceRequired;
    private string label;
    private EquipmentSlot equipCode;
    private int damage;
    private int resistance;
    private int durability;
    private int maxDurability;

    // Default Constructor
    public Item()
    {
        this.uniqueID = Guid.NewGuid();
        this.Girth = 1;
        this.Label = "Mysterious Item";
        this.Equip = EquipmentSlot.Unequipable;
        this.Damage = 0;
        this.Resistance = 0;
        this.Durability = 1;
        this.MaxDurability = 1;
    }

    // Specific Constructor
    public Item(int girth, string label, EquipmentSlot equipable)
    {
        this.uniqueID = Guid.NewGuid();
        this.Girth = girth;
        this.Label = label;
        this.Equip = equipable;
        this.Damage = 0;
        this.Resistance = 0;
        this.Durability = 1;
        this.MaxDurability = 1;
    }

    // Specific Constructor
    public Item(int girth, string label, EquipmentSlot equipable, int dmg, int res, int dur)
    {
        this.uniqueID = Guid.NewGuid();
        this.Girth = girth;
        this.Label = label;
        this.Equip = equipable;
        this.Damage = dmg;
        this.Resistance = res;
        this.Durability = dur;
        this.MaxDurability = this.Durability;
    }

    public Guid ID
    {
        get { return this.uniqueID; }
        set { /*Should Not Change*/ }
    }

    public int Girth
    {
        get { return this.inventorySpaceRequired; }
        set
        {
            if (value >= 0)
            {
                this.inventorySpaceRequired = value;
            }
        }
    }

    public string Label
    {
        get { return this.label; }
        set { this.label = value; }
    }

    public EquipmentSlot Equip
    {
        get { return this.equipCode; }
        set { this.equipCode = value; }
    }

    public int Damage
    {
        get { return this.damage; }
        set { this.damage = value; }
    }

    public int Resistance
    {
        get { return this.resistance; }
        set { this.resistance = value; }
    }

    public int Durability
    {
        get { return this.durability; }
        set
        {
            this.durability = value;
            // Negative Threshold
            if (this.durability < 0)
            {
                this.durability = 0;
            }
            // Max Threshold
            if (this.durability > this.maxDurability)
            {
                this.MaxDurability = this.durability;
            }
        }
    }

    public int MaxDurability
    {
        get { return this.maxDurability; }
        set
        {
            this.maxDurability = value;
            // Negative Threshold
            if (this.maxDurability < 0)
            {
                this.maxDurability = 0;
            }
            // Durability Check
            if (this.durability > this.maxDurability)
            {
                this.durability = this.maxDurability;
            }
        }
    }

    public int OutgoingDamage()
    {
        return this.Damage;
    }

    public int DamageResistance()
    {
        return this.Resistance;
    }

    public virtual void OnUse()
    {
        this.Durability--;
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
