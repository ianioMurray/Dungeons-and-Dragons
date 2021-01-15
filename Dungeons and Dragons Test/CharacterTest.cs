using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Dungeons_and_Dragons;
using Dungeons_and_Dragons.InteractItems;

namespace Dungeons_and_Dragons_Test
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void TestIncreaseExperiencePoints_WithAMinus20PercentModifier()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 9);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 13);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 8;
            Character character = new Fighter("Bob", Race.Dwarf, dict, hp, xp);
            character.SetExperiencePointMultiplier(-20);

            character.IncreaseExperiencePoints(100);

            Assert.AreEqual(80, character.experiencePoints, "TEST1: The number of Experience Points returned was not as expected");
        }

        [TestMethod]
        public void TestIncreaseExperiencePoints_WithAPositive5PercentModifier()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 4;
            Character character = new Thief("Mo", Race.Elf, dict, hp, xp);
            character.SetExperiencePointMultiplier(5);

            character.IncreaseExperiencePoints(100);

            Assert.AreEqual(105, character.experiencePoints, "TEST1: The number of Experience Points returned was not as expected");
        }

        [TestMethod]
        public void TestIncreaseExperiencePoints_WithAPositive10PercentModifier()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 7);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 14);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 2;
            Character character = new MagicUser("Morris", Race.Halfling, dict, hp, xp);
            character.SetExperiencePointMultiplier(10);

            character.IncreaseExperiencePoints(91);

            Assert.AreEqual(100, character.experiencePoints, "TEST1: The number of Experience Points returned was not as expected");
        }

        [TestMethod]
        public void TestGetAdditionalHitPointsForNewLevel_WhereTheCalculatedHPArePositive()
        {
            int constitution = 13;

            Assert.AreEqual(4, Character.GetAdditionalHitPointsForNewLevel(3, AttributeBonuses.GetConstitution_HitPointBonus(constitution)), "The hit points were not as expected");
        }

        [TestMethod]
        public void TestSetStaringHitPoints_WhereTheCalculatedHPAreZero()
        {
            int constitution = 6;

            Assert.AreEqual(1, Character.GetAdditionalHitPointsForNewLevel(2, AttributeBonuses.GetConstitution_HitPointBonus(constitution)), "The hit points were not as expected");
        }

        [TestMethod]
        public void TestSetStaringHitPoints_WhereTheCalculatedHPAreNegative()
        {
            int constitution = 3;

            Assert.AreEqual(1, Character.GetAdditionalHitPointsForNewLevel(2, AttributeBonuses.GetConstitution_HitPointBonus(constitution)), "The hit points were not as expected");
        }

        [TestMethod]
        public void TestAddToCharactersInventory()
        {
            int initialItemsInInvetory = 0;
            int OneItemInInventory = 1;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 7);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 14);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 2;
            Character character = new MagicUser("Morris", Race.Halfling, dict, hp, xp);

            ShortSword shortSword = new ShortSword();

            Assert.AreEqual(initialItemsInInvetory, character.inventory.Count, "TEST1: The number of items in the character's inventory is not as expected");

            character.AddToCharactersInventory(shortSword);

            Assert.AreEqual(OneItemInInventory, character.inventory.Count, "TEST2: The number of items in the character's inventory is not as expected");
        }



    }
}
