using System;
using System.Collections.Generic;

namespace Model.ModelObjects.Person
{
    public class NPC : Person
    {
        private List<string> dialogue;
        private Random rand;
        private int health;

        public NPC()
        {
            this.dialogue = new List<string>();
            this.rand = new Random();
            this.health = 10;
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

            if (damageAfterResistance < 0)
            {
                damageAfterResistance = 0;
            }
            this.health -= damageAfterResistance;
            if (this.health < 0)
            {
                this.health = 0;
            }
            OnChanged(EventArgs.Empty);
        }

        public override void OnUpdate()
        {
            Console.WriteLine("OnUpdate: I'm a NPC");
        }

        public override void OnTime()
        {
            Console.WriteLine("OnTime: I'm a NPC");
        }

        public string Speak()
        {
            if (dialogue.Count == 0)
            {
                return "Hello World";
            }
            int radomIndex = rand.Next(this.dialogue.Count);
            return dialogue[radomIndex];
        }

        public List<string> getDialogue()
        {
            return this.dialogue;
        }

        public void setDialogue(List<string> phrases)
        {
            this.dialogue = phrases;
            OnChanged(EventArgs.Empty);
        }

        public override string Info()
        {
            System.Text.StringBuilder toString = new System.Text.StringBuilder();
            toString.Append("NPC\n");
            toString.Append("Is ");
            toString.Append(base.Info());
            return toString.ToString();
        }
    }
}
