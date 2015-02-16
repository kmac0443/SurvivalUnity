using System;
using System.Collections.Generic;

namespace ModelRepresentation.ModelObjects
{
    interface IDamageAffecting
    {
        int OutgoingDamage();
        int DamageResistance();
    }
}
