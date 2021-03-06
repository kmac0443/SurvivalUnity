﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory : StorageContainer, IDamageAffecting
{
    private List<Item> equipment;
    private const int EQUIPABLECOUNT = 5; // EquipmentSlot Enum

    // Default Constructor
    public Inventory()
    {
        this.MaxCapacity = 25;
        this.Capacity = 0;
        this.Items = new List<Item>();
        this.Equipment = new List<Item>();
        for (int i = 0; i < EQUIPABLECOUNT; i++)
        {
            this.Equipment.Add(null);
        }
    }

    // Specific Constructor
    public Inventory(int max, int current)
        : this()
    {
        this.MaxCapacity = max;
        this.Capacity = current;
    }

    public List<Item> Equipment
    {
        get { return this.equipment; }
        set
        {
            if (value != null)
            {
                this.equipment = value;
            }
        }
    }

    public bool EquipItem(Item item)
    {
        if (null == item)   // Can't equip nothing
        {
            return false;
        }
        if (item.Equip == EquipmentSlot.Unequipable)
        {
            return false;
        }

        // Equip Item - Arms Case
        if (item.Equip.Equals(EquipmentSlot.LeftArm) || item.Equip.Equals(EquipmentSlot.RightArm) || item.Equip.Equals(EquipmentSlot.BothArms))
        {
            return EquipArmSlots(item);
        }

        // Everything Else - Nothing There
        if (this.Equipment[(int)item.Equip] == null)    // If there is nothing in that Equipment spot
        {
            this.Equipment[(int)item.Equip] = item;     // Put item into Equipment
            this.RemoveItem(item);                      // Remove item from inventory
            return true;
        }

        // Everything Else - Something There
        if (this.Equipment[(int)item.Equip] != null)    // There is equipment currently there
        {
            // Can we add the currently equiped item back into the inventory?
            if (UnEquipItem(Equipment[(int)item.Equip]))
            {
                this.Equipment[(int)item.Equip] = item;     // Put item into Equipment
                this.RemoveItem(item);                      // Remove item from inventory
                return true;
            }
            // Edge case where Inventory is full but we could swap items
            else if (Equipment[(int)item.Equip].Girth == item.Girth)
            {
                this.RemoveItem(item);                      // Remove item to be equipped from inventory
                this.AddItem(Equipment[(int)item.Equip]);   // Move other item from Equipment into Inventory
                this.Equipment[(int)item.Equip] = item;     // Put item into Equipment
                return true;
            }
        }
        return false;
    }

    private bool EquipArmSlots(Item item)
    {
        // Both Arms Case
        if (item.Equip.Equals(EquipmentSlot.BothArms))
        {
            int neededSpace = 0;
            if (this.equipment[(int)EquipmentSlot.LeftArm] != null)
            {
                neededSpace += this.equipment[(int)EquipmentSlot.LeftArm].Girth;
            }
            if (this.equipment[(int)EquipmentSlot.RightArm] != null)
            {
                neededSpace += this.equipment[(int)EquipmentSlot.RightArm].Girth;
            }
            if (this.equipment[(int)EquipmentSlot.BothArms] != null)
            {
                neededSpace += this.equipment[(int)EquipmentSlot.BothArms].Girth;
            }

            // Do we Have room to move Items from Equipment to Inventory?
            if (this.MaxCapacity - this.Capacity >= neededSpace)
            {
                UnEquipItem(Equipment[(int)EquipmentSlot.LeftArm]);
                UnEquipItem(Equipment[(int)EquipmentSlot.RightArm]);
                UnEquipItem(Equipment[(int)EquipmentSlot.BothArms]);
                this.Equipment[(int)item.Equip] = item;     // Put item into Equipment
                this.RemoveItem(item);                      // Remove item from inventory
                return true;
            }
            return false;
        }

        // Right Arm Case
        if (item.Equip.Equals(EquipmentSlot.RightArm))
        {
            int neededSpace = 0;
            if (this.equipment[(int)EquipmentSlot.RightArm] != null)
            {
                neededSpace += this.equipment[(int)EquipmentSlot.RightArm].Girth;
            }
            if (this.equipment[(int)EquipmentSlot.BothArms] != null)
            {
                neededSpace += this.equipment[(int)EquipmentSlot.BothArms].Girth;
            }

            // Do we Have room to move Items from Equipment to Inventory?
            if (this.MaxCapacity - this.Capacity >= neededSpace)
            {
                UnEquipItem(Equipment[(int)EquipmentSlot.RightArm]);
                UnEquipItem(Equipment[(int)EquipmentSlot.BothArms]);
                this.Equipment[(int)item.Equip] = item;     // Put item into Equipment
                this.RemoveItem(item);                      // Remove item from inventory
                return true;
            }
            return false;
        }

        // Left Arm Case
        if (item.Equip.Equals(EquipmentSlot.LeftArm))
        {
            int neededSpace = 0;
            if (this.equipment[(int)EquipmentSlot.LeftArm] != null)
            {
                neededSpace += this.equipment[(int)EquipmentSlot.LeftArm].Girth;
            }
            if (this.equipment[(int)EquipmentSlot.BothArms] != null)
            {
                neededSpace += this.equipment[(int)EquipmentSlot.BothArms].Girth;
            }
            // Do we Have room to move Items from Equipment to Inventory?
            if (this.MaxCapacity - this.Capacity >= neededSpace)
            {
                UnEquipItem(Equipment[(int)EquipmentSlot.LeftArm]);
                UnEquipItem(Equipment[(int)EquipmentSlot.BothArms]);
                this.Equipment[(int)item.Equip] = item;     // Put item into Equipment
                this.RemoveItem(item);                      // Remove item from inventory
                return true;
            }
            return false;
        }
        return false;
    }

    public bool UnEquipItem(Item item)
    {
        if (item == null)
        {
            return true;
        }

        if (this.Equipment[(int)item.Equip].ID != item.ID)
        {
            return false;
        }

        if (this.AddItem(Equipment[(int)item.Equip]))
        {
            Equipment[(int)item.Equip] = null;
            return true;
        }
        return false;
    }

    public int OutgoingDamage()
    {
        int damage = 0;
        foreach (Item i in Equipment)
        {
            if (i != null)
            {
                damage += i.Damage;
            }
        }
        return damage;
    }

    public int DamageResistance()
    {
        int resistance = 0;
        foreach (Item i in Equipment)
        {
            if (i != null)
            {
                resistance += i.Resistance;
            }
        }
        return resistance;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
