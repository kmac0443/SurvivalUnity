using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalUnityModel.Scripts.Classes.Person
{
    class Player : Person
    {
        public Player()
        {
        }

        public override void OnUpdate()
        {
            Console.WriteLine("OnUpdate: I'm a Player");
        }

        public override void OnTime()
        {
            Console.WriteLine("OnTime: I'm a Player");
        }
    }
}
