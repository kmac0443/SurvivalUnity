using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRepresentation.ModelObjects.Person
{
    class NPC : Person
    {
        public NPC()
        {
        }

        public override int DealDamage()
        {
            int damage = 0;
            damage += base.inventory.OutgoingDamage();
            return damage;
        }

        public override void ReceiveDamage(int damage)
        {
            int damageAfterResistance = damage;
            damageAfterResistance -= base.inventory.DamageResistance();
            //TODO
        }

        public override void OnUpdate()
        {
            Console.WriteLine("OnUpdate: I'm a NPC");
        }

        public override void OnTime()
        {
            Console.WriteLine("OnTime: I'm a NPC");
        }

        public override string Info()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append("NPC\n");
            toString.Append("Is ");
            toString.Append(base.Info());
            return toString.ToString();
        }
    }
}
