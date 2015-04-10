using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Meter
{
    private int min;
    private int max;
    private int current;
    private int degradeRate;

    public Meter()
    {
        this.min = 0;
        this.max = 100;
        this.current = this.max;
        this.degradeRate = 1;
    }

    public Meter(int min, int max, int current, int degradeRate)
    {
        this.min = min;
        this.max = max;
        this.current = current;
        this.degradeRate = degradeRate;
    }

    public int Min
    {
        get { return this.min; }
        set { this.min = value; }
    }

    public int Max
    {
        get { return this.max; }
        set
        {
            this.max = value;
            if (this.current > this.max)
            {
                this.current = this.max;
            }
        }
    }

    public int Current
    {
        get { return this.current; }
        set
        {
            this.current = value;
            if (this.current > this.max)
            {
                this.current = this.max;
            }
        }
    }

    public int Rate
    {
        get { return this.degradeRate; }
        set { this.degradeRate = value; }
    }

    public void Increase(int amount)
    {
        this.Current += Math.Abs(amount);
		if (Current > Max) Current = Max;
    }

    public void Decrease(int amount)
    {
        this.Current -= Math.Abs(amount);
		if (Current < Min) Current = Min;
    }

	public double Percent() {
		return (double)(current - min) / (double)(max - min);
	}
}
