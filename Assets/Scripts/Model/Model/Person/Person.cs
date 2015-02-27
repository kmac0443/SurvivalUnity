using Model.ModelObjects.ItemManagement;
using Model.ModelObjects.Items;
using System;
using System.Collections.Generic;

namespace Model.ModelObjects.Person
{
    public class Person : IUnity
    {
        protected Inventory inventory;
        public event ChangedEventHandler Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }

        public Person()
        {
            this.inventory = new Inventory();
        }

        public bool AddItem(Item item)
        {
            bool success = this.inventory.AddItem(item);
            if (success)
            {
                OnChanged(EventArgs.Empty);
            }
            return success;
        }

        public bool RemoveItem(Item item)
        {
            bool success = this.inventory.RemoveItem(item);
            if (success)
            {
                OnChanged(EventArgs.Empty);
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
            Console.WriteLine("OnTime: I'm a Person");
        }

        public virtual void OnUpdate()
        {
            Console.WriteLine("OnUpdate: I'm a Person");
        }

        public virtual string Info()
        {
            System.Text.StringBuilder toString = new System.Text.StringBuilder();
            toString.Append("Person:\n");
            toString.Append("Has ");
            toString.Append(this.inventory.Info());
            return toString.ToString();
        }
    }
}
