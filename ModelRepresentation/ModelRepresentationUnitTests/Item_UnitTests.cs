using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelRepresentation.ModelObjects.Items;

namespace ModelRepresentationUnitTests
{
    [TestClass]
    public class Item_UnitTests
    {
        [TestMethod]
        public void Item_Constructors()
        {
            int girth = 10;
            string label = "text";
            int equipable = 3;
            int damge = 2;
            int resistance = 2;
            int durability = 10;

            Item general = new Item();
            Assert.AreEqual(general.Girth, 1);
            Assert.AreEqual(general.Label, "Mysterious Item");
            Assert.AreEqual(general.Equip, -1);
            Assert.AreEqual(general.Damage, 0);
            Assert.AreEqual(general.Resistance, 0);
            Assert.AreEqual(general.Durability, 1);

            Item specificA = new Item(girth, label, equipable);
            Assert.AreEqual(specificA.Girth, girth);
            Assert.AreEqual(specificA.Label, label);
            Assert.AreEqual(specificA.Equip, equipable);
            Assert.AreEqual(specificA.Damage, 0);
            Assert.AreEqual(specificA.Resistance, 0);
            Assert.AreEqual(specificA.Durability, 1);

            Item specificB = new Item(girth, label, equipable, damge, resistance, durability);
            Assert.AreEqual(specificB.Girth, girth);
            Assert.AreEqual(specificB.Label, label);
            Assert.AreEqual(specificB.Equip, equipable);
            Assert.AreEqual(specificB.Damage, damge);
            Assert.AreEqual(specificB.Resistance, resistance);
            Assert.AreEqual(specificB.Durability, durability);
        }

        [TestMethod]
        public void Item_Properties()
        {
            int girth = 10;
            string label = "text";
            int equipable = 3;
            int damge = 2;
            int resistance = 2;
            int durability = 10;

            Item specificB = new Item(girth, label, equipable, damge, resistance, durability);
            Assert.AreEqual(specificB.Girth, girth);
            Assert.AreEqual(specificB.Label, label);
            Assert.AreEqual(specificB.Equip, equipable);
            Assert.AreEqual(specificB.Damage, damge);
            Assert.AreEqual(specificB.Resistance, resistance);
            Assert.AreEqual(specificB.Durability, durability);

            specificB.Girth = 20;
            Assert.AreEqual(specificB.Girth, 20);

            specificB.Label = "helloWorld";
            Assert.AreEqual(specificB.Label, "helloWorld");

            specificB.Equip = -1;
            Assert.AreEqual(specificB.Equip, -1);

            specificB.Damage = 0;
            Assert.AreEqual(specificB.Damage, 0);

            specificB.Resistance = 0;
            Assert.AreEqual(specificB.Resistance, 0);

            specificB.Durability = 5;
            Assert.AreEqual(specificB.Durability, 5);
        }
    }
}
