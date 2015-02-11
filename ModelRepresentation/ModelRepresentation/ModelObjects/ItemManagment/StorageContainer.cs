using ModelRepresentation.ModelObjects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRepresentation.ModelObjects.ItemManagment
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

        public int MaxCapacity
        {
            get { return this.maxCapacity; }
            set
            {
                if (value >= 0)
                {
                    this.maxCapacity = value;
                }
                else
                {
                    this.maxCapacity = 0;
                }
            }
        }

        public int Capacity
        {
            get { return this.currentCapacity; }
            set
            {
                if (value >= 0)
                {
                    this.currentCapacity = value;
                }
                else
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
                if (null != value)
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
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == item.ID)
                {
                    return false;
                }
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
            StringBuilder toString = new StringBuilder();
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
