using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalUnityModel.Scripts.Model.Person
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

        public override string Info()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append("NPC\n");
            toString.Append("Is ");
            toString.Append(base.Info());
            return toString.ToString();
        }
    }
}
