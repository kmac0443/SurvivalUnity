using Model.ModelObjects.ItemManagement;
using Model.ModelObjects.Items;
using System;
using System.Collections.Generic;

namespace Model.ModelObjects.Person
{
    public class Person : IUnity
    {
        protected Inventory inventory;

        public Person()
        {
            this.inventory = new Inventory();
        }

        public bool AddItem(Item item)
        {
            return this.inventory.AddItem(item);
        }

        public bool RemoveItem(Item item)
        {
            return this.inventory.RemoveItem(item);
        }

        public virtual int DealDamage()
        {
            return 0;
            /* implemented in children */
        }

        public virtual void ReceiveDamage(int damage)
        {
            return;
            /* implemented in children */
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
