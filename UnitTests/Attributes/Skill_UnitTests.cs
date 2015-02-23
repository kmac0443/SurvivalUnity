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
    public class Skill_UnitTests
    {
        [TestMethod()]
        public void Skill_Test()
        {
            Skill skill = new Skill();
            
            //ID is read only
            Guid id = skill.ID;
            Assert.AreEqual(id, skill.ID);
            skill.ID = new Guid();
            Assert.AreEqual(id, skill.ID);
        }

        [TestMethod()]
        public void OutgoingDamage_Test()
        {
            Skill skill = new Skill();
            Assert.AreEqual(0, skill.OutgoingDamage());
        }

        [TestMethod()]
        public void DamageResistance_Test()
        {
            Skill skill = new Skill();
            Assert.AreEqual(0, skill.DamageResistance());
        }
    }
}
