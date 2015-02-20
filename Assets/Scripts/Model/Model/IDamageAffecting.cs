using System;
using System.Collections.Generic;

namespace Model.ModelObjects
{
    public interface IDamageAffecting
    {
        int OutgoingDamage();
        int DamageResistance();
    }
}
