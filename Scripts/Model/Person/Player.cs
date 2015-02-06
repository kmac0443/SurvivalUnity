using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalUnityModel.Scripts.Model.Person
{
    class Player : Person
    {
        public Player()
        {
        }

        public void LevelUp()
        {
            //TODO
            this.attributes.IncreaseAttributes(1,1,1,1);
        }

        public override void OnUpdate()
        {
            Console.WriteLine("OnUpdate: I'm a Player");
        }

        public override void OnTime()
        {
            Console.WriteLine("OnTime: I'm a Player");
        }

        public override string Info()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append("Player\n");
            toString.Append("Is ");
            toString.Append(base.Info());
            return toString.ToString();
        }
    }
}
