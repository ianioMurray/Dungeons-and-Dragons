using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Dungeons_and_Dragons;

namespace Dungeons_and_Dragons_Test
{
    [TestClass]
    public class AttributeBonusesTest
    {
        [TestMethod]
        public void TestGetPrimeRequisiteXPBonus_WhereBonusIsMinus20()
        {
            var ret1 = AttributeBonuses.GetPrimeRequisiteXPBonus(3);

            Assert.AreEqual(-20, ret1, "TEST1: The returned string is not as expected");


            var ret2 = AttributeBonuses.GetPrimeRequisiteXPBonus(5);

            Assert.AreEqual(-20, ret2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetPrimeRequisiteXPBonus_WhereBonusIsMinus10()
        {
            var ret1 = AttributeBonuses.GetPrimeRequisiteXPBonus(6);

            Assert.AreEqual(-10, ret1, "TEST1: The returned string is not as expected");


            var ret2 = AttributeBonuses.GetPrimeRequisiteXPBonus(8);

            Assert.AreEqual(-10, ret2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetPrimeRequisiteXPBonus_WhereBonusIsZero()
        {
            var ret1 = AttributeBonuses.GetPrimeRequisiteXPBonus(9);

            Assert.AreEqual(0, ret1, "TEST1: The returned string is not as expected");


            var ret2 = AttributeBonuses.GetPrimeRequisiteXPBonus(12);

            Assert.AreEqual(0, ret2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetPrimeRequisiteXPBonus_WhereBonusIsPlusFive()
        {
            var ret1 = AttributeBonuses.GetPrimeRequisiteXPBonus(13);

            Assert.AreEqual(5, ret1, "TEST1: The returned string is not as expected");


            var ret2 = AttributeBonuses.GetPrimeRequisiteXPBonus(15);

            Assert.AreEqual(5, ret2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetPrimeRequisiteXPBonus_WhereBonusIsPlusTen()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var ret1 = AttributeBonuses.GetPrimeRequisiteXPBonus(16);

            Assert.AreEqual(10, ret1, "TEST1: The returned string is not as expected");


            var ret2 = AttributeBonuses.GetPrimeRequisiteXPBonus(18);

            Assert.AreEqual(10, ret2, "TEST2: The returned string is not as expected");
        }
    }
}
