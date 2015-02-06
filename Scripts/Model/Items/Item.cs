using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalUnityModel.Scripts.Model.Items
{
    public class Item
    {
        private Guid uniqueID;
        private int inventorySpaceRequired;
        private string label;
        private int equipCode;
        private int damage;
        private int resistance;

        // Default Constructor
        public Item()
        {
            this.uniqueID = Guid.NewGuid();
            this.Girth = 1;
            this.Label = "Mysterious Item";
            this.Equip = -1;
            this.Damage = 0;
            this.Resistance = 0;
        }

        // Specific Constructor
        public Item(int girth, string label, int equipable)
        {
            this.uniqueID = Guid.NewGuid();
            this.Girth = girth;
            this.Label = label;
            this.Equip = equipable;
            this.Damage = 0;
            this.Resistance = 0;
        }

        public Guid ID
        {
            get { return this.uniqueID; }
            set { /*Should Not Change*/ }
        }

        public int Girth
        {
            get { return this.inventorySpaceRequired; }
            set
            {
                if (value >= 0)
                {
                    this.inventorySpaceRequired = value;
                }
            }
        }

        public string Label 
        {
            get { return this.label; }
            set { this.label = value; }
        }

        public int Equip
        {
            get { return this.equipCode; }
            set { this.equipCode = value; }
        }
                
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public int Resistance
        {
            get { return resistance; }
            set { resistance = value; }
        }

        public string Info()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(Label + " ");
            toString.Append(Girth + " ");
            toString.Append(Equip + " ");
            toString.Append(ID + " ");
            toString.Append("\n");
            return toString.ToString();
        }
    }
}
