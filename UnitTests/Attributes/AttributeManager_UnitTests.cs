using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ModelObjects.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Model.ModelObjects.Attributes.Tests
{
    [TestClass()]
    public class AttributeManager_UnitTests
    {
        [TestMethod()]
        public void AttributeManager_Test()
        {
            AttributeManager attributeManager = new AttributeManager();
            Assert.AreEqual(1, attributeManager.Constitution);
            Assert.AreEqual(1, attributeManager.Strength);
            Assert.AreEqual(1, attributeManager.Intelligence);
            Assert.AreEqual(1, attributeManager.Dexterity);
        }

        [TestMethod()]
        public void AttributeManager_Test1()
        {
            int customValue = 5;
            AttributeManager attributeManager = new AttributeManager(customValue,customValue,customValue,customValue);
            Assert.AreEqual(customValue, attributeManager.Constitution);
            Assert.AreEqual(customValue, attributeManager.Strength);
            Assert.AreEqual(customValue, attributeManager.Intelligence);
            Assert.AreEqual(customValue, attributeManager.Dexterity);
        }

        [TestMethod()]
        public void OutgoingDamage_Test()
        {
            AttributeManager attributeManager = new AttributeManager();
            Assert.AreEqual(2, attributeManager.OutgoingDamage());
        }

        [TestMethod()]
        public void DamageResistance_Test()
        {
            AttributeManager attributeManager = new AttributeManager();
            Assert.AreEqual(2, attributeManager.DamageResistance());
        }

        [TestMethod()]
        public void Info_Test()
        {
            AttributeManager attributeManager = new AttributeManager();
            String info = "Attributes:\nConst: 1\nStren: 1\nIntel: 1\nDexte: 1\n";
            Assert.AreEqual(info, attributeManager.Info());

            attributeManager = new AttributeManager(5,5,5,5);
            info = "Attributes:\nConst: 5\nStren: 5\nIntel: 5\nDexte: 5\n";
            Assert.AreEqual(info, attributeManager.Info());
        }
    }
}
