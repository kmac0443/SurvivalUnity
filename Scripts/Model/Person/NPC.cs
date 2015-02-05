using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalUnityModel.Scripts.Classes.Person
{
    class NPC : Person
    {
        public NPC()
        {

        }

        public override void OnUpdate()
        {
            Console.WriteLine("OnUpdate: I'm a NPC");
        }

        public override void OnTime()
        {
            Console.WriteLine("OnTime: I'm a NPC");
        }
    }
}
