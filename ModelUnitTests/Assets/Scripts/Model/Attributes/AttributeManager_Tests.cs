using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests
{
    [TestClass()]
    public class AttributeManager_Tests
    {
        [TestMethod()]
        public void AttributeManager_Test()
        {
            AttributeManager attributeManager = new AttributeManager();
            Assert.AreEqual(1, attributeManager.Constitution);
            Assert.AreEqual(1, attributeManager.Strength);
            Assert.AreEqual(1, attributeManager.Intelligence);
            Assert.AreEqual(1, attributeManager.Dexterity);

            int customValue = 5;
            attributeManager = new AttributeManager(customValue, customValue, customValue, customValue);
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
    }
}
