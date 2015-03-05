using UnityEngine;
using System.Collections;

public interface IDamageAffecting
{
    int OutgoingDamage();
    int DamageResistance();
}
