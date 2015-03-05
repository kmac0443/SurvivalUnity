using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Vitals : MonoBehaviour {

    private Dictionary<MeterType, Meter> meters;

    public Vitals()
    {
        this.meters = new Dictionary<MeterType, Meter>();
        this.meters[MeterType.Ash] = new Meter(0, 100, 0, 1);
        this.meters[MeterType.Food] = new Meter(0, 100, 100, -1);
        this.meters[MeterType.Water] = new Meter(0, 100, 100, -5);
        this.meters[MeterType.Health] = new Meter(0, 100, 100, 0);
        this.meters[MeterType.Stamina] = new Meter(0, 100, 100, -1);
    }

    public int Min(MeterType key)
    {
        if (this.meters.ContainsKey(key))
        {
            return this.meters[key].Min;
        }
        else
        {
            return 0;
        }
    }

    public int Max(MeterType key)
    {
        if (this.meters.ContainsKey(key))
        {
            return this.meters[key].Max;
        }
        else
        {
            return 0;
        }
    }

    public int Current(MeterType key)
    {
        if (this.meters.ContainsKey(key))
        {
            return this.meters[key].Current;
        }
        else
        {
            return 0;
        }
    }

    public void Increase(MeterType key, int amount)
    {
        if (this.meters.ContainsKey(key))
        {
            this.meters[key].Increase(amount);
        }
    }

    public void Decrease(MeterType key, int amount)
    {
        if (this.meters.ContainsKey(key))
        {
            this.meters[key].Decrease(amount);
        }
    }

    //////////////////////
    /// Unity Specific ///
    ////////////////////// 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



}
