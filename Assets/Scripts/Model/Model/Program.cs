using ModelRepresentation.ModelObjects.Attributes;
using ModelRepresentation.ModelObjects.ItemManagment;
using ModelRepresentation.ModelObjects.Items;
using ModelRepresentation.ModelObjects.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRepresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Attributes
            AttributeManager attManager = new AttributeManager();
            Skill skill = new Skill();
            SkillManager skillManager = new SkillManager();

            //ItemManagment
            Inventory inventory = new Inventory();
            StorageContainer storageContainer = new StorageContainer();
            StorageContainer sc_inv = new Inventory();

            //Items
            Item item = new Item();

            //Person
            Person person = new Person();
            Player player = new Player();
            NPC npc = new NPC();
            Person generalPlayer = new Player();
            Person generalNPC = new NPC();

        }
    }
}
