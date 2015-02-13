﻿using ModelRepresentation.ModelObjects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRepresentation.ModelObjects.ItemManagment
{
    public class Inventory : StorageContainer, IDamageAffecting
    {
        private List<Item> equipment;
        private const int EQUIPABLECOUNT = 5;

        // Default Constructor
        public Inventory()
        {
            this.MaxCapacity = 100;
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
        {
            this.MaxCapacity = max;
            this.Capacity = current;
            this.Items = new List<Item>();
            this.Equipment = new List<Item>();
            for (int i = 0; i < EQUIPABLECOUNT; i++)
            {
                this.Equipment.Add(null);
            }
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
            if (item.Equip < 0 || item.Equip > EQUIPABLECOUNT)   // Equip Code of -1 means it's non equipable
            {
                return false;
            }
            if (this.Equipment[item.Equip] == null) // If there is nothing in that Equipment spot
            {
                this.Equipment[item.Equip] = item;  // Put item into Equipment
                this.RemoveItem(item);              // Remove item from inventory
                return true;
            }
            if (this.Equipment[item.Equip] != null) // There is equipment currently there
            {
                // Can we add the currently equiped item back into the inventory?
                if (UnEquipItem(Equipment[item.Equip]))
                {
                    this.Equipment[item.Equip] = item;  // Put item into Equipment
                    this.RemoveItem(item);              // Remove item from inventory
                    return true;
                }
                // Edge case where Inventory is full but we could swap items
                else if (Equipment[item.Equip].Girth == item.Girth)
                {
                    this.RemoveItem(item);              // Make space
                    this.AddItem(Equipment[item.Equip]);// Move from Equipment into Inventory
                    this.Equipment[item.Equip] = item;  // Put item into Equipment
                    return true;
                }
            }
            return false;
        }

        public bool UnEquipItem(Item item)
        {
            for (int i = 0; i < EQUIPABLECOUNT; i++)
            {
                if (Equipment[i] == null)   // Nothing currently Equiped in that slot
                {
                    continue;
                }
                else if (Equipment[i].ID == item.ID)
                {
                    if (this.AddItem(Equipment[i])) // Add back to Inventory
                    {
                        Equipment[i] = null;
                        return true;
                    }
                    return false;
                }
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

        public override string Info()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append("Inventory:\n");
            toString.Append("Is ");
            toString.Append(base.Info());
            return toString.ToString();
        }
    }
}