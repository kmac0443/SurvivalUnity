using System;
using System.Collections.Generic;

namespace Model.ModelObjects
{
    interface IDamageAffecting
    {
        int OutgoingDamage();
        int DamageResistance();
    }
}
