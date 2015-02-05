using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalUnityModel.Scripts.Classes.Items
{
    class Item
    {
        private Guid uniqueID;
        private int inventorySpaceRequired;

        public Item()
        {
            this.uniqueID = Guid.NewGuid();
            this.inventorySpaceRequired = 1;
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

        public Guid ID
        {
            get { return this.uniqueID; }
            set { /* Cannot Change   */ }
        }

    }
}
