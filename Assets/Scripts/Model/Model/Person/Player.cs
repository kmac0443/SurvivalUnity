using Model.MeterManagement;
using Model.ModelObjects.Attributes;
using System;
using System.Collections.Generic;

namespace Model.ModelObjects.Person
{
    public class Player : Person
    {        
        private AttributeManager attributes;
        private SkillManager skills;
        private Vitals vitals;
        
        public Player()
        {
            this.vitals = new Vitals();
            this.attributes = new AttributeManager();
            this.skills = new SkillManager();
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

            if (damageAfterResistance < 0)
            {
                damageAfterResistance = 0;
            }
            this.vitals.Decrease(MeterType.Health, damageAfterResistance);
        }

        public override void OnUpdate()
        {
            Console.WriteLine("OnUpdate: I'm a Player");
            this.vitals.OnUpdate();
        }

        public override void OnTime()
        {
            Console.WriteLine("OnTime: I'm a Player");
            this.vitals.OnTime();
        }

        public override string Info()
        {
            System.Text.StringBuilder toString = new System.Text.StringBuilder();
            toString.Append("Player\n");
            toString.Append("Is ");
            toString.Append(base.Info());
            return toString.ToString();
        }
    }
}
