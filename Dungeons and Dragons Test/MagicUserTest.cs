using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Dungeons_and_Dragons;
using Dungeons_and_Dragons.InteractItems;

namespace Dungeons_and_Dragons_Test
{
    [TestClass]
    public class MagicUserTest
    {
        [TestMethod]
        public void SetMagicUserLevelTest()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 4);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence,10);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 4;
            MagicUser magicUser = new MagicUser("Gandolf", Race.Human, dict, hp, xp);

            magicUser.IncreaseExperiencePoints(0);

            Assert.AreEqual(1, magicUser.currentLevel, "TEST1: The level is not as expected");

            magicUser.IncreaseExperiencePoints(2499);

            Assert.AreEqual(1, magicUser.currentLevel, "TEST2: The level is not as expected");

            magicUser.IncreaseExperiencePoints(1);

            Assert.AreEqual(2, magicUser.currentLevel, "TEST3: The level is not as expected");

            magicUser.IncreaseExperiencePoints(2499);

            Assert.AreEqual(2, magicUser.currentLevel, "TEST4: The level is not as expected");

            magicUser.IncreaseExperiencePoints(1);

            Assert.AreEqual(3, magicUser.currentLevel, "TEST5: The level is not as expected");
        }

        [TestMethod]
        public void TestEquipToHand_WhereWeaponIsUseableByAMagicUser()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 4);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 4;
            MagicUser magicUser = new MagicUser("Gandolf", Race.Human, dict, hp, xp);

            NormalDagger dagger = new NormalDagger();

            Assert.IsNull(magicUser.equippedInRightHand, "TEST1: It was expected that nothing should be equipped to the Magic-User's right hand");

            bool val = magicUser.EquipToHand(dagger, Hand.Right);

            Assert.IsTrue(val, "TEST2: It was expected equipping the dagger to the right hand should return true");
            Assert.AreEqual(dagger, magicUser.equippedInRightHand, "TEST3: It was expected that the dagger should be equipped");
            Assert.IsNull(magicUser.equippedInLeftHand, "TEST4: It was expected that the left hand is empty");
        }

        [TestMethod]
        public void TestEquipToHand_WhereWeaponIsNotUseableByAMagicUser()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 4);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 4;
            MagicUser magicUser = new MagicUser("Gandolf", Race.Human, dict, hp, xp);

            Sword sword = new Sword();

            Assert.IsNull(magicUser.equippedInRightHand, "TEST1: It was expected that nothing should be equipped to the Magic-User's right hand");

            bool val = magicUser.EquipToHand(sword, Hand.Right);

            Assert.IsFalse(val, "TEST2: It was expected equipping the sword to the right hand should return false");
            Assert.IsNull(magicUser.equippedInRightHand, "TEST3: It was expected that the right hand is empty");
            Assert.IsNull(magicUser.equippedInLeftHand, "TEST4: It was expected that the left hand is empty");
        }
    }
}