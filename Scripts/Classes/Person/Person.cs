using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivialUnityPrototype.Scripts.Classes.Person
{
    class Person : Unity
    {
        public int MAX_HEALTH;
        public int currentHealth;
        //public PersonAttributes attributes;
        private Inventory inventory;

        public Person()
        {
            this.MAX_HEALTH = 100;
            this.currentHealth = 100;
            //this.attributes = new PersonAttributes();
            this.inventory = new Inventory();
        }

        public virtual void OnTime()
        {
            Console.WriteLine("OnTime: I'm a Person");
        }
        public virtual void OnUpdate()
        {
            Console.WriteLine("OnUpdate: I'm a Person");
        }

        
    }
}
