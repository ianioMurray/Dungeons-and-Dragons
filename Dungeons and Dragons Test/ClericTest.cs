using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dungeons_and_Dragons;
using Dungeons_and_Dragons.InteractItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons_and_Dragons_Test
{
    [TestClass]
    public class ClericTest
    {
        [TestMethod]
        public void SetClericLevelTest()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 1;
            Cleric cleric = new Cleric("Fryer Ben", Race.Halfling, dict, hp, xp);

            cleric.IncreaseExperiencePoints(0);

            Assert.AreEqual(1, cleric.currentLevel, "TEST1: The level is not as expected");

            cleric.IncreaseExperiencePoints(1499);

            Assert.AreEqual(1, cleric.currentLevel, "TEST2: The level is not as expected");

            cleric.IncreaseExperiencePoints(1);

            Assert.AreEqual(2, cleric.currentLevel, "TEST3: The level is not as expected");

            cleric.IncreaseExperiencePoints(1499);

            Assert.AreEqual(2, cleric.currentLevel, "TEST4: The level is not as expected");

            cleric.IncreaseExperiencePoints(1);

            Assert.AreEqual(3, cleric.currentLevel, "TEST5: The level is not as expected");
        }

        [TestMethod]
        public void TestEquipToHand_WhereWeaponIsUseableByACleric()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 1;
            Cleric cleric = new Cleric("Fryer Ben", Race.Halfling, dict, hp, xp);

            Mace mace = new Mace();

            Assert.IsNull(cleric.equippedInRightHand, "TEST1: It was expected that nothing should be equipped to the Cleric's right hand");

            bool val = cleric.EquipToHand(mace, Hand.Right);

            Assert.IsTrue(val, "TEST2: It was expected equipping the mace to the right hand should return true");
            Assert.AreEqual(mace, cleric.equippedInRightHand, "TEST3: It was expected that the mace should be equipped");
            Assert.IsNull(cleric.equippedInLeftHand, "TEST4: It was expected that the left hand is empty");
        }

        [TestMethod]
        public void TestEquipToHand_WhereWeaponIsNotUseableByACleric()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 1;
            Cleric cleric = new Cleric("Fryer Ben", Race.Halfling, dict, hp, xp);

            Sword sword = new Sword();

            Assert.IsNull(cleric.equippedInRightHand, "TEST1: It was expected that nothing should be equipped to the Cleric's right hand");

            bool val = cleric.EquipToHand(sword, Hand.Right);

            Assert.IsFalse(val, "TEST2: It was expected equipping the sword to the right hand should return false");
            Assert.IsNull(cleric.equippedInRightHand, "TEST3: It was expected that the right hand is empty");
            Assert.IsNull(cleric.equippedInLeftHand, "TEST4: It was expected that the left hand is empty");
        }

        [TestMethod]
        public void TestEquipToBody_EnsureArmourClassIsCorrectWithNoArmourNoShieldOrBonus()
        {
            int expectedArmourClass = 9;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 1;
            Cleric cleric = new Cleric("Fryer Ben", Race.Halfling, dict, hp, xp);

            Assert.AreEqual(expectedArmourClass, cleric.armourClass, "The Cleric's expected AC was 9");
        }

        [TestMethod]
        public void TestEquipToBody_EnsureArmourClassIsCorrectWithAMinusThreeBonusButNoArmourNoShield()
        {
            int expectedArmourClass = 6;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 1);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 1;
            Cleric cleric = new Cleric("Fryer Ben", Race.Halfling, dict, hp, xp);

            Assert.AreEqual(expectedArmourClass, cleric.armourClass, "The Cleric's expected AC was 6");
        }

        [TestMethod]
        public void TestEquipToBody_EnsureArmourClassIsCorrectWithAPlusThreeBonusWhichGivesAnArmourClassOfOverNine()
        {
            int expectedArmourClass = 9;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 1);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 1;
            Cleric cleric = new Cleric("Fryer Ben", Race.Halfling, dict, hp, xp);

            Assert.AreEqual(expectedArmourClass, cleric.armourClass, "The Cleric's expected AC was 9");
        }

        [TestMethod]
        public void TestEquipToBody_EnsureArmourClassIsCorrectWithLeatherArmourButNoShieldOrBonus()
        {
            int expectedArmourClass = 7;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 1);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 1;
            Cleric cleric = new Cleric("Fryer Ben", Race.Halfling, dict, hp, xp);

            LeatherArmour leatherArmour = new LeatherArmour();

            bool valEquipped = cleric.EquipToBody(leatherArmour);

            Assert.IsTrue(valEquipped, "TEST1: It was expected that equipping Leather Armour returns true");
            Assert.AreEqual(expectedArmourClass, cleric.armourClass, "The Cleric's expected AC was 7");
        }

        [TestMethod]
        public void TestEquipToBody_EnsureArmourClassIsCorrectWithChainMailButNoShieldOrBonus()
        {
            int expectedArmourClass = 5;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 1);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 1;
            Cleric cleric = new Cleric("Fryer Ben", Race.Halfling, dict, hp, xp);

            ChainMail chainMail = new ChainMail();

            bool valEquipped = cleric.EquipToBody(chainMail);

            Assert.IsTrue(valEquipped, "TEST1: It was expected that equipping Chain Mail returns true");
            Assert.AreEqual(expectedArmourClass, cleric.armourClass, "The Cleric's expected AC was 5");
        }

        [TestMethod]
        public void TestEquipToBody_EnsureArmourClassIsCorrectWithPlateMailButNoShieldOrBonus()
        {
            int expectedArmourClass = 3;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 1);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 1;
            Cleric cleric = new Cleric("Fryer Ben", Race.Halfling, dict, hp, xp);

            PlateMail plateMail = new PlateMail();

            bool valEquipped = cleric.EquipToBody(plateMail);

            Assert.IsTrue(valEquipped, "TEST1: It was expected that equipping Plate Mail returns true");
            Assert.AreEqual(expectedArmourClass, cleric.armourClass, "The Cleric's expected AC was 3");
        }

        [TestMethod]
        public void TestEquipToHand_EnsureArmourClassIsCorrectAShieldButNoArmourOrBonus()
        {
            int expectedArmourClass = 8;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 1);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 1;
            Cleric cleric = new Cleric("Fryer Ben", Race.Halfling, dict, hp, xp);

            Shield shield = new Shield();

            bool valEquipped = cleric.EquipToHand(shield, Hand.Left);

            Assert.IsTrue(valEquipped, "TEST1: It was expected that equipping shield returns true");
            Assert.AreEqual(expectedArmourClass, cleric.armourClass, "The Cleric's expected AC was 8");
        }
    }
}
