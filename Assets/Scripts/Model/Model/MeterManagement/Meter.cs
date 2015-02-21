using System;
using System.Collections.Generic;

namespace Model.ModelObjects.MeterManagment
{
    public class Meter
    {
        private int min;
        private int max;
        private int current;

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
            set { this.current = value; }
        }

        public void onHour()
        {

        }

        public void change(int amount)
        {

        }
    }
}
