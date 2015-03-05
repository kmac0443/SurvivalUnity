using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Skill : MonoBehaviour, IDamageAffecting
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

    //////////////////////
    /// Unity Specific ///
    ////////////////////// 
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
