using ModelRepresentation.ModelObjects.ItemManagment;
using ModelRepresentation.ModelObjects.Items;
using System;
using System.Collections.Generic;

namespace ModelRepresentation.ModelObjects.Person
{
    class Person : IUnity
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
            StringBuilder toString = new StringBuilder();
            toString.Append("Person:\n");
            toString.Append("Has ");
            toString.Append(this.inventory.Info());
            return toString.ToString();
        }
    }
}
