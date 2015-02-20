using Model.ModelObjects.ItemManagement;
using Model.ModelObjects.Items;
using System;
using System.Collections.Generic;

namespace Model.World
{
    public class Mineable
    {
        private StorageContainer storage;
        private bool itemsLeft;
        private int effort;
        private int currentEffort;

        public Mineable()
        {
            Active = false;
            Items = new StorageContainer();
            EffortRequired = 1;
            currentEffort = 0;            
        }

        public StorageContainer Items
        {
            get { return this.storage; }
            set
            {
                if(null == value)
                {
                    Active = false;
                    this.currentEffort = 0;
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

        public int EffortRequired
        {
            get { return this.effort; }
            set { this.effort = value; }
        }

        public bool Active
        {
            get { return this.itemsLeft; }
            set { this.itemsLeft = value; }
        }

        public Item Mine()
        {
            if (!Active)
            {
                return null;
            }
            currentEffort++;
            if (currentEffort >= EffortRequired)
            {
                currentEffort -= EffortRequired;
                Item i = Items.Items[0];
                Items.RemoveItem(i);

                if (Items.Capacity == 0)
                {
                    Active = false;
                }
                return i;
            }
            return null;
        }
    }
}
