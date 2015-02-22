using Model.ModelObjects.Items;
using System;
using System.Collections.Generic;

namespace Model.ModelObjects.ItemManagement
{
    public class StorageContainer
    {
        private int maxCapacity;
        private int currentCapacity;
        private List<Item> items;

        public StorageContainer()
        {
            this.MaxCapacity = 100;
            this.Capacity = 0;
            this.Items = new List<Item>();
        }

        private bool Contains(Guid id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public int MaxCapacity
        {
            get { return this.maxCapacity; }
            set
            {
                this.maxCapacity = value;
                // Negative Threshold
                if (this.maxCapacity < 0)
                {
                    this.maxCapacity = 0;
                }
                // Current Threshold
                if (this.currentCapacity > this.maxCapacity)
                {
                    this.currentCapacity = this.maxCapacity;
                }
            }
        }

        public int Capacity
        {
            get { return this.currentCapacity; }
            set
            {
                this.currentCapacity = value;
                // Negative Threshold
                if (this.currentCapacity < 0)
                {
                    this.currentCapacity = 0;
                }
            }
        }

        public List<Item> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                if (value != null)
                {
                    this.items = value;
                }
                else
                {
                    this.items = new List<Item>();
                }
            }
        }

        public bool AddItem(Item item)
        {
            if (null == item)
            {
                return false;
            }
            // Duplicate Check
            if (this.Contains(item.ID))
            {
                return false;
            }
            // Capacity Check
            if (this.Capacity + item.Girth <= this.MaxCapacity)
            {
                this.items.Add(item);
                this.Capacity += item.Girth;
                return true;
            }
            return false;
        }

        public bool RemoveItem(Item item)
        {
            if (null == item)
            {
                return false;
            }

            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].ID == item.ID)
                {
                    this.Capacity -= this.items[i].Girth;
                    this.items.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public virtual string Info()
        {
            System.Text.StringBuilder toString = new System.Text.StringBuilder();
            toString.Append("Storage Container:\n");
            toString.Append("Cap: ");
            toString.Append(this.Capacity);
            toString.Append(" Max: ");
            toString.Append(this.MaxCapacity);
            toString.Append("\n");
            for (int i = 0; i < items.Count; i++)
            {
                toString.Append(i);
                toString.Append(" " + items[i].Info());
            }
            return toString.ToString();
        }
    }
}
