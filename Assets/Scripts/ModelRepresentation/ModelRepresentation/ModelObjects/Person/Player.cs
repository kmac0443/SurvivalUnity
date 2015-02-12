using ModelRepresentation.ModelObjects.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRepresentation.ModelObjects.Person
{
    class Player : Person
    {
        private AttributeManager attributes;
        protected SkillManager skills;

        public Player()
        {
        }

        public override int DealDamage()
        {
            int damage = 0;
            damage += this.attributes.OutgoingDamage();
            damage += base.inventory.OutgoingDamage();
            damage += this.skills.OutgoingDamage();
            return damage;
        }

        public override void ReceiveDamage(int damage)
        {
            int damageAfterResistance = damage;
            damageAfterResistance -= this.attributes.DamageResistance();
            damageAfterResistance -= base.inventory.DamageResistance();
            damageAfterResistance -= this.skills.DamageResistance();
            //TODO
        }

        public override void OnUpdate()
        {
            Console.WriteLine("OnUpdate: I'm a Player");
        }

        public override void OnTime()
        {
            Console.WriteLine("OnTime: I'm a Player");
        }

        public override string Info()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append("Player\n");
            toString.Append("Is ");
            toString.Append(base.Info());
            return toString.ToString();
        }
    }
}
