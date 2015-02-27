using Model.ModelObjects;
using Model.ModelObjects.MeterManagment;
using System;
using System.Collections.Generic;

namespace Model.MeterManagement
{
    public enum MeterType
    {
        Ash,
        Food,
        Water,
        Health,
        Stamina,
    }

    public class Vitals : IUnity
    {
        private Dictionary<MeterType, Meter> meters;

        public Vitals()
        {
            this.meters = new Dictionary<MeterType, Meter>();
            this.meters[MeterType.Stamina] = new Meter(0, 100, 100, -1);
            this.meters[MeterType.Ash] = new Meter(0, 100, 0, 1);
            this.meters[MeterType.Food] = new Meter(0, 100, 100, -1);
            this.meters[MeterType.Water] = new Meter(0, 100, 100, -5);
            this.meters[MeterType.Health] = new Meter(0, 100, 100, 0);
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

        public void OnUpdate()
        {
            foreach(MeterType key in this.meters.Keys)
            {
                this.meters[key].OnUpdate();
            }
        }

        public void OnTime()
        {
            foreach (MeterType key in this.meters.Keys)
            {
                this.meters[key].OnTime();
            }
        }
    }
}
