using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ModelObjects.Person;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.ModelObjects.Items;
namespace Model.ModelObjects.Person.Tests
{
    [TestClass()]
    public class Person_UnitTests
    {
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
            //TODO: Meaningful Test
        }

        [TestMethod()]
        public void ReceiveDamage_Test()
        {
            //TODO: Meaningful Test
        }

    }
}
