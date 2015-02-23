using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ModelObjects.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.ItemManagement;
namespace Model.ModelObjects.Items.Tests
{
    [TestClass()]
    public class Item_UnitTests
    {
        [TestMethod()]
        public void Item_Test()
        {
            Item item = new Item();
            Assert.AreEqual(1, item.Girth);
            Assert.AreEqual("Mysterious Item", item.Label);
            Assert.AreEqual(EquipmentSlot.Unequipable, item.Equip);
            Assert.AreEqual(0, item.Damage);
            Assert.AreEqual(0, item.Resistance);
            Assert.AreEqual(1, item.Durability);
            Assert.AreEqual(1, item.MaxDurability);
        }

        [TestMethod()]
        public void Item_Test1()
        {
            int girth = 100;
            string label = "item";
            EquipmentSlot equipCode = EquipmentSlot.Feet;
            
            Item item = new Item(girth, label, equipCode);
            Assert.AreEqual(girth, item.Girth);
            Assert.AreEqual(label, item.Label);
            Assert.AreEqual(equipCode, item.Equip);
            Assert.AreEqual(0, item.Damage);
            Assert.AreEqual(0, item.Resistance);
            Assert.AreEqual(1, item.Durability);
            Assert.AreEqual(1, item.MaxDurability);
        }

        [TestMethod()]
        public void Item_Test2()
        {
            int girth = 100;
            string label = "item";
            EquipmentSlot equipCode = EquipmentSlot.Feet;
            int dmg = 10;
            int res = 15;
            int dur = 5;

            Item item = new Item(girth, label, equipCode, dmg, res, dur);
            Assert.AreEqual(girth, item.Girth);
            Assert.AreEqual(label, item.Label);
            Assert.AreEqual(equipCode, item.Equip);
            Assert.AreEqual(dmg, item.Damage);
            Assert.AreEqual(res, item.Resistance);
            Assert.AreEqual(dur, item.Durability);
            Assert.AreEqual(dur, item.MaxDurability);
        }

        [TestMethod()]
        public void OutgoingDamage_Test()
        {
            Item item = new Item();
            item.Damage = 100;
            Assert.AreEqual(item.Damage, item.OutgoingDamage());
        }

        [TestMethod()]
        public void DamageResistance_Test()
        {
            Item item = new Item();
            item.Resistance = 100;
            Assert.AreEqual(item.Resistance, item.DamageResistance());
        }

        [TestMethod()]
        public void OnUse_Test()
        {
            Item item = new Item();
            Assert.AreEqual(1, item.Durability);

            item.OnUse();
            Assert.AreEqual(0, item.Durability);
        }
        
    }
}
