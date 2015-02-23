using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ModelObjects.ItemManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.ModelObjects.Items;
namespace Model.ModelObjects.ItemManagement.Tests
{
    [TestClass()]
    public class StorageContainer_UnitTests
    {
        [TestMethod()]
        public void StorageContainer_Test()
        {
            StorageContainer storage = new StorageContainer();
            Assert.AreEqual(100, storage.MaxCapacity);
            Assert.AreEqual(0, storage.Capacity);
            Assert.AreEqual(0, storage.Items.Count);
        }

        [TestMethod()]
        public void AddItem_Test()
        {
            StorageContainer storage = new StorageContainer();
            Assert.AreEqual(0, storage.Items.Count);

            Item mock = new Item();
            int girth = mock.Girth;
            Assert.IsTrue(storage.AddItem(mock));
            Assert.AreEqual(1, storage.Items.Count);
            Assert.AreEqual(girth, storage.Capacity);
        }

        [TestMethod()]
        public void RemoveItem_Test()
        {
            StorageContainer storage = new StorageContainer();
            Assert.AreEqual(0, storage.Items.Count);

            Item mock = new Item();
            int girth = mock.Girth;
            Assert.IsTrue(storage.AddItem(mock));
            Assert.AreEqual(1, storage.Items.Count);
            Assert.AreEqual(girth, storage.Capacity);

            Assert.IsTrue(storage.RemoveItem(mock));            
            Assert.AreEqual(0, storage.Items.Count);
            Assert.AreEqual(0, storage.Capacity);
        }

    }
}
