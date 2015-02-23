using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ModelObjects.ItemManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.ModelObjects.Items;
using Model.ItemManagement;
namespace Model.ModelObjects.ItemManagement.Tests
{
    [TestClass()]
    public class Inventory_UnitTests
    {
        [TestMethod()]
        public void Inventory_Test()
        {
            Inventory inventory = new Inventory();
            Assert.AreEqual(100, inventory.MaxCapacity);
            Assert.AreEqual(0, inventory.Capacity);
        }

        [TestMethod()]
        public void Inventory_Test1()
        {
            int max = 5;
            int current = 2;
            Inventory inventory = new Inventory(max, current);
            Assert.AreEqual(max, inventory.MaxCapacity);
            Assert.AreEqual(current, inventory.Capacity);
        }

        [TestMethod()]
        public void EquipItem_Test()
        {
            // Mock objects
            Item mock = new Item();
            Guid id = mock.ID;
            mock.Equip = EquipmentSlot.Head;

            Item mock2 = new Item();
            Guid id2 = mock2.ID;
            mock2.Equip = EquipmentSlot.Head;

            // Equip with nothing there
            Inventory inventory = new Inventory();
            inventory.AddItem(mock);
            Assert.AreEqual(1, inventory.Items.Count);
            for (int i = 0; i < inventory.Equipment.Count; i++)
            {
                Assert.AreEqual(null, inventory.Equipment[i]);
            }

            Assert.IsTrue(inventory.EquipItem(mock));
            Assert.AreEqual(0, inventory.Items.Count);
            Assert.AreEqual(mock, inventory.Equipment[(int)mock.Equip]);
            Assert.AreEqual(id, inventory.Equipment[(int)EquipmentSlot.Head].ID);

            // Equip with something there
            inventory.AddItem(mock2);
            Assert.AreEqual(1, inventory.Items.Count);

            inventory.EquipItem(mock2);
            Assert.AreEqual(1, inventory.Items.Count);
            Assert.AreEqual(id, inventory.Items[0].ID);
            Assert.AreEqual(mock2, inventory.Equipment[(int)mock2.Equip]);
            Assert.AreEqual(id2, inventory.Equipment[(int)EquipmentSlot.Head].ID);

            // Equip with something there and no additional room
            inventory.Capacity = 1;
            inventory.EquipItem(mock);
            Assert.AreEqual(1, inventory.Items.Count);
            Assert.AreEqual(id, inventory.Equipment[(int)EquipmentSlot.Head].ID);
        }

        [TestMethod()]
        public void UnEquipItem_Test()
        {
            // Mock objects
            Item mock = new Item();
            Guid id = mock.ID;
            mock.Equip = EquipmentSlot.Head;

            // Equip with nothing there
            Inventory inventory = new Inventory();
            inventory.AddItem(mock);
            Assert.AreEqual(1, inventory.Items.Count);
            for (int i = 0; i < inventory.Equipment.Count; i++)
            {
                Assert.AreEqual(null, inventory.Equipment[i]);
            }

            Assert.IsTrue(inventory.EquipItem(mock));
            Assert.AreEqual(0, inventory.Items.Count);
            Assert.AreEqual(mock, inventory.Equipment[(int)mock.Equip]);
            Assert.AreEqual(id, inventory.Equipment[(int)EquipmentSlot.Head].ID);

            Assert.IsTrue(inventory.UnEquipItem(mock));
            Assert.AreEqual(1, inventory.Items.Count);
        }

        [TestMethod()]
        public void OutgoingDamage_Test()
        {
            // Mock objects
            Item mock = new Item();
            mock.Equip = EquipmentSlot.RightArm;
            mock.Damage = 99;

            Inventory inventory = new Inventory();
            Assert.IsTrue(inventory.AddItem(mock));
            Assert.AreEqual(0, inventory.OutgoingDamage());
            Assert.IsTrue(inventory.EquipItem(mock));
            Assert.AreEqual(99, inventory.OutgoingDamage());
        }

        [TestMethod()]
        public void DamageResistance_Test()
        {
            // Mock objects
            Item mock = new Item();
            mock.Equip = EquipmentSlot.RightArm;
            mock.Resistance = 99;

            Inventory inventory = new Inventory();
            Assert.IsTrue(inventory.AddItem(mock));
            Assert.AreEqual(0, inventory.DamageResistance());
            Assert.IsTrue(inventory.EquipItem(mock));
            Assert.AreEqual(99, inventory.DamageResistance());
        }

    }
}
