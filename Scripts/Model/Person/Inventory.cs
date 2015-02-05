using SurvivalUnityModel.Scripts.Classes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalUnityModel.Scripts.Classes.Person
{
    class Inventory
    {
        private int maxCapacity;
        private int currentCapacity;
        private List<Item> items;

        // Default Constructor
        public Inventory()
        {
            this.MaxCapacity = 100;
            this.currentCapacity = 100;
        }

        // Specific Constructor
        public Inventory(int max, int current)
        {
            this.MaxCapacity = max;
            this.currentCapacity = current;
        }

        public int MaxCapacity
        {
            get { return this.maxCapacity; }
            set 
            {
                if(value >= 0)
                {
                    this.maxCapacity = value;
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
                    this.maxCapacity = value;
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
            }
        }

        public bool AddItem(Item item)
        {
            if (null == item)
            {
                return false;
            }
            
            if (this.Capacity + item.Girth < this.MaxCapacity)
            {
                this.items.Add(item);
                return true;
            }
            
            return false;
        }

        public bool RemoveItem(Item item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].ID == item.ID)
                {
                    this.items.RemoveAt(i);
                    return true;
                    break;
                }
            }
            return false;
        }



    }
}
