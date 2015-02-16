using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelRepresentation.ModelObjects.ItemManagment;
using ModelRepresentation.ModelObjects.Items;

namespace ModelRepresentationUnitTests
{
    [TestClass]
    public class ItemManagement_UnitTests
    {
        [TestMethod]
        public void StorageContainer_Constructor()
        {
            StorageContainer testContainer = new StorageContainer();
            Assert.AreEqual(testContainer.MaxCapacity, 100);
            Assert.AreEqual(testContainer.Capacity, 0);
            Assert.AreEqual(testContainer.Items.Count, 0);
        }

        [TestMethod]
        public void StorageContainer_AddItem()
        {
            StorageContainer testContainer = new StorageContainer();

            // Cannot add null
            Item nullItem = null;
            Assert.IsFalse(testContainer.AddItem(nullItem));
            Assert.AreEqual(testContainer.MaxCapacity, 100);
            Assert.AreEqual(testContainer.Capacity, 0);
            Assert.AreEqual(testContainer.Items.Count, 0);

            // Add Legit Item
            Item item = new Item();
            Assert.IsTrue(testContainer.AddItem(item));
            Assert.AreEqual(testContainer.MaxCapacity, 100);
            Assert.AreEqual(testContainer.Capacity, 1);
            Assert.AreEqual(testContainer.Items.Count, 1);

            // Cannot Add duplicates
            Assert.IsFalse(testContainer.AddItem(item));
            Assert.AreEqual(testContainer.MaxCapacity, 100);
            Assert.AreEqual(testContainer.Capacity, 1);
            Assert.AreEqual(testContainer.Items.Count, 1);

            // Fill to Capacity
            Assert.IsTrue(testContainer.AddItem(new Item(99, "full", 0)));
            Assert.AreEqual(testContainer.MaxCapacity, 100);
            Assert.AreEqual(testContainer.Capacity, 100);
            Assert.AreEqual(testContainer.Items.Count, 2);

            // Cannot Add another
            Assert.IsFalse(testContainer.AddItem(new Item(99, "full", 0)));


        }

        [TestMethod]
        public void StorageContainer_RemoveItem()
        {
            StorageContainer testContainer = new StorageContainer();
            Item item = new Item();
            Assert.IsTrue(testContainer.AddItem(item));
            Assert.AreEqual(testContainer.MaxCapacity, 100);
            Assert.AreEqual(testContainer.Capacity, 1);
            Assert.AreEqual(testContainer.Items.Count, 1);

            // Remove Null item
            Assert.IsFalse(testContainer.RemoveItem(null));
            Assert.AreEqual(testContainer.MaxCapacity, 100);
            Assert.AreEqual(testContainer.Capacity, 1);
            Assert.AreEqual(testContainer.Items.Count, 1);

            // Remove Real item
            Assert.IsTrue(testContainer.RemoveItem(item));
            Assert.AreEqual(testContainer.MaxCapacity, 100);
            Assert.AreEqual(testContainer.Capacity, 0);
            Assert.AreEqual(testContainer.Items.Count, 0);

            // Remove Real Item, not in there
            Assert.IsFalse(testContainer.RemoveItem(item));
            Assert.AreEqual(testContainer.MaxCapacity, 100);
            Assert.AreEqual(testContainer.Capacity, 0);
            Assert.AreEqual(testContainer.Items.Count, 0);

        }

        [TestMethod]
        public void StorageContainer_Inventory()
        {
            Inventory testInventory = new Inventory();
            Assert.AreEqual(testInventory.MaxCapacity, 100);
            Assert.AreEqual(testInventory.Capacity, 0);
            Assert.AreEqual(testInventory.Items.Count, 0);

            Inventory testInventoryCustom = new Inventory(50, 50);
            Assert.AreEqual(testInventoryCustom.Capacity, 50);
            Assert.AreEqual(testInventoryCustom.Items.Count, 0);
        }

        [TestMethod]
        public void Inventory_EquipItem()
        {
            Inventory testInventory = new Inventory();

            // Item has an equip code of -1 Cannot be equiped
            Item item = new Item(20, "item", -1);
            Assert.IsTrue(testInventory.AddItem(item));
            Assert.IsFalse(testInventory.EquipItem(item));

            // Fill inventory
            item = new Item(20, "item", 0);
            testInventory.AddItem(item);
            item = new Item(20, "item", 1);
            testInventory.AddItem(item);
            item = new Item(20, "item", 2);
            testInventory.AddItem(item);
            item = new Item(20, "item", 3);
            testInventory.AddItem(item);
            Assert.AreEqual(testInventory.Capacity, 100);

            // Equiping Item decreases inventory capacity
            Assert.IsTrue(testInventory.EquipItem(item));
            Assert.IsTrue(testInventory.Capacity != 100);
            Assert.IsTrue(testInventory.Capacity == 80);
            Guid equipedItemID = item.ID;

            // Restore full capacity
            item = new Item(20, "item", 3);
            Guid inventoryItemID = item.ID;
            testInventory.AddItem(item);
            Assert.IsTrue(testInventory.Capacity == 100);

            // Given Full Inventory
            // Can we equip an item that has equal capacity
            // This should swap an Equiped Item for an Item in the inventory
            Assert.IsTrue(testInventory.EquipItem(item));
            Assert.AreEqual(testInventory.Equipment[3].ID, inventoryItemID);
        }

        [TestMethod]
        public void Inventory_UnEquip()
        {
            Inventory testInventory = new Inventory();
            Item a = new Item(1, "item", 0);
            Assert.IsTrue(testInventory.AddItem(a));
            Assert.AreEqual(testInventory.Items.Count, 1);

            Assert.IsTrue(testInventory.EquipItem(a));
            Assert.AreEqual(testInventory.Items.Count, 0);
            Assert.AreEqual(testInventory.Equipment[0].ID, a.ID);

            Assert.IsTrue(testInventory.UnEquipItem(a));
            Assert.AreEqual(testInventory.Items.Count, 1);
            Assert.AreEqual(testInventory.Equipment[0], null);
        }
    }
}
