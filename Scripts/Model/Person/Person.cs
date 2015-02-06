using SurvivalUnityModel.Scripts.Model.Items;
using SurvivalUnityModel.Scripts.Model.Attributes;
using SurvivalUnityModel.Scripts.Model.ItemManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalUnityModel.Scripts.Model.Person
{
    class Person : Unity
    {
        protected AttributeManager attributes;
        protected Inventory inventory;

        public Person()
        {            
            this.attributes = new AttributeManager();
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

        public int DealDamage()
        {
            //TODO: need damage from equipment and skills
            int damage = 0;
            damage += this.attributes.OutgoingDamage();
            damage += this.inventory.OutgoingDamage();
            
            return damage;
        }

        public void RecieveDamage(int damage)
        {
            //TODO: need resistance from equipment and skills
            int damageAfterResistance = damage;
            damageAfterResistance -= this.attributes.DamageResistance();
            damageAfterResistance -= this.inventory.DamageResistance();
            
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
            toString.Append("Has ");
            toString.Append(this.attributes.Info());

            return toString.ToString();
        }
    }
}
