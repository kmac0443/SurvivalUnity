using System;
using System.Collections.Generic;

namespace Model.ModelObjects.Attributes
{
    class Skill : IDamageAffecting
    {
        private Guid uniqueID;

        public Skill()
        {
            this.uniqueID = new Guid();
        }

        public Guid ID
        {
            get { return this.uniqueID; }
            set { /*Cannot change ID*/  }
        }

        public int OutgoingDamage()
        {
            //TODO
            return 0;
        }

        public int DamageResistance()
        {
            //TODO
            return 0;
        }
    }
}
