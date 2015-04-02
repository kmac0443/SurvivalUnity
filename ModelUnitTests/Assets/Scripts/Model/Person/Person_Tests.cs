using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests
{
    [TestClass()]
    public class Person_Tests
    {
        [TestMethod()]
        public void Person_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddItem_Test()
        {
            Person person = new Person();
            Item item = new Item();
            Assert.IsTrue(person.AddItem(item));
            Assert.IsTrue(person.RemoveItem(item));
            Assert.IsFalse(person.RemoveItem(item));
        }

        [TestMethod()]
        public void RemoveItem_Test()
        {
            Person person = new Person();
            Item item = new Item();
            Assert.IsTrue(person.AddItem(item));
            Assert.IsTrue(person.RemoveItem(item));
            Assert.IsFalse(person.RemoveItem(item));
        }

        [TestMethod()]
        public void DealDamage_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReceiveDamage_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OnTime_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OnUpdate_Test()
        {
            Assert.Fail();
        }
    }
}
