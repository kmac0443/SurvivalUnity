using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set { this.max = value; }
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
