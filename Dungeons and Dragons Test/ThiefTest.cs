using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dungeons_and_Dragons;
using Dungeons_and_Dragons.InteractItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons_and_Dragons_Test
{
    [TestClass]
    public class ThiefTest
    {
        [TestMethod]
        public void SetThiefLevelTest()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Thief thief = new Thief("Stickie", Race.Elf, dict, hp, xp);

            thief.IncreaseExperiencePoints(0);

            Assert.AreEqual(1, thief.currentLevel, "TEST1: The level is not as expected");

            thief.IncreaseExperiencePoints(1199);

            Assert.AreEqual(1, thief.currentLevel, "TEST2: The level is not as expected");

            thief.IncreaseExperiencePoints(1);

            Assert.AreEqual(2, thief.currentLevel, "TEST3: The level is not as expected");

            thief.IncreaseExperiencePoints(1199);

            Assert.AreEqual(2, thief.currentLevel, "TEST4: The level is not as expected");

            thief.IncreaseExperiencePoints(1);

            Assert.AreEqual(3, thief.currentLevel, "TEST5: The level is not as expected");
        }

        [TestMethod]
        public void TestSetThievesAbilities_WhereCharacterIsFirstLevel()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 14);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 6);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 14);
            int xp = 0;
            int hp = 3;
            Thief thief = new Thief("MarkyMark", Race.Elf, dict, hp, xp);

            Assert.AreEqual(15, thief.thievingAbilities[ThiefAbilities.PickLock],
                "TEST1: The value returned for PickLock was not as expected");
            Assert.AreEqual(10, thief.thievingAbilities[ThiefAbilities.FindRemoveTraps],
                "TEST2: The value returned for Find/Remove traps was not as expected");
            Assert.AreEqual(20, thief.thievingAbilities[ThiefAbilities.PickPocket],
                "TEST3: The value returned for pick pocket was not as expected");
            Assert.AreEqual(20, thief.thievingAbilities[ThiefAbilities.MoveSilently],
                "TEST4: The value returned for move silently was not as expected");
            Assert.AreEqual(87, thief.thievingAbilities[ThiefAbilities.ClimbSheerSurfaces],
                "TEST5: The value returned for climb sheer surfaces was not as expected");
            Assert.AreEqual(10, thief.thievingAbilities[ThiefAbilities.HideInShadows],
                "TEST6: The value returned for hide in shadows was not as expected");
            Assert.AreEqual(33, thief.thievingAbilities[ThiefAbilities.HearNoise],
                "TEST7: The value returned for hear noise was not as expected");
        }

        [TestMethod]
        public void TestSetThievesAbilities_WhereCharacterIsSecondLevel()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 14);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 6);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 14);
            int xp = 1200;
            int hp = 3;
            Thief thief = new Thief("MarkyMark", Race.Elf, dict, hp, xp);

            Assert.AreEqual(20, thief.thievingAbilities[ThiefAbilities.PickLock],
                "TEST1: The value returned for PickLock was not as expected");
            Assert.AreEqual(15, thief.thievingAbilities[ThiefAbilities.FindRemoveTraps],
                "TEST2: The value returned for Find/Remove traps was not as expected");
            Assert.AreEqual(25, thief.thievingAbilities[ThiefAbilities.PickPocket],
                "TEST3: The value returned for pick pocket was not as expected");
            Assert.AreEqual(25, thief.thievingAbilities[ThiefAbilities.MoveSilently],
                "TEST4: The value returned for move silently was not as expected");
            Assert.AreEqual(88, thief.thievingAbilities[ThiefAbilities.ClimbSheerSurfaces],
                "TEST5: The value returned for climb sheer surfaces was not as expected");
            Assert.AreEqual(15, thief.thievingAbilities[ThiefAbilities.HideInShadows],
                "TEST6: The value returned for hide in shadows was not as expected");
            Assert.AreEqual(33, thief.thievingAbilities[ThiefAbilities.HearNoise],
                "TEST7: The value returned for hear noise was not as expected");
        }

        [TestMethod]
        public void TestSetThievesAbilities_WhereCharacterIsThirdLevel()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 14);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 6);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 14);
            int xp = 2400;
            int hp = 3;
            Thief thief = new Thief("MarkyMark", Race.Elf, dict, hp, xp);

            Assert.AreEqual(25, thief.thievingAbilities[ThiefAbilities.PickLock],
                "TEST1: The value returned for PickLock was not as expected");
            Assert.AreEqual(20, thief.thievingAbilities[ThiefAbilities.FindRemoveTraps],
                "TEST2: The value returned for Find/Remove traps was not as expected");
            Assert.AreEqual(30, thief.thievingAbilities[ThiefAbilities.PickPocket],
                "TEST3: The value returned for pick pocket was not as expected");
            Assert.AreEqual(30, thief.thievingAbilities[ThiefAbilities.MoveSilently],
                "TEST4: The value returned for move silently was not as expected");
            Assert.AreEqual(89, thief.thievingAbilities[ThiefAbilities.ClimbSheerSurfaces],
                "TEST5: The value returned for climb sheer surfaces was not as expected");
            Assert.AreEqual(20, thief.thievingAbilities[ThiefAbilities.HideInShadows],
                "TEST6: The value returned for hide in shadows was not as expected");
            Assert.AreEqual(50, thief.thievingAbilities[ThiefAbilities.HearNoise],
                "TEST7: The value returned for hear noise was not as expected");
        }

        [TestMethod]
        public void TestEquipToBody_EquippingShieldWhichIsNotUseableByAThief()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Thief thief = new Thief("Stickie", Race.Elf, dict, hp, xp);

            Shield shield = new Shield();

            bool valShieldEquipped = thief.EquipToHand(shield, Hand.Left);

            Assert.IsFalse(valShieldEquipped, "TEST1: It is expected that the a thief cannot equip a shield");
            Assert.IsNull(thief.equippedToBody, "TEST2: It was expected that the shield is NOT equipped");
        }

        [TestMethod]
        public void TestTestEquipToHand_TryingToEquipAmrourToAHandThatShouldEquipToBody()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Thief thief = new Thief("Stickie", Race.Elf, dict, hp, xp);

            LeatherArmour leatherArmour = new LeatherArmour();

            bool valArmourEquipped = thief.EquipToHand(leatherArmour, Hand.Right);

            Assert.IsFalse(valArmourEquipped, "TEST1: It is expected that the Armour will not be equipped");
            Assert.IsNull(thief.equippedInRightHand, "TEST2: It was expected that the right hand should be empty");
            Assert.IsNull(thief.equippedInLeftHand, "TEST3: It was expected that the left hand should be empty");
        }

        [TestMethod]
        public void TestEquipToBody_EquippingArmourThatAThiefCanUse()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Thief thief = new Thief("Stickie", Race.Elf, dict, hp, xp);

            LeatherArmour leatherArmour = new LeatherArmour();

            bool valArmourEquipped = thief.EquipToBody(leatherArmour);

            Assert.IsTrue(valArmourEquipped, "TEST1: It is expected that the Armour will be equipped");
            Assert.AreEqual(leatherArmour, thief.equippedToBody, "TEST2: It was expected that the leather armour is now equipped");
        }

        [TestMethod]
        public void TestEquipToBody_EquippingArmourThatAThiefCannotUse()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Thief thief = new Thief("Stickie", Race.Elf, dict, hp, xp);

            ChainMail chainArmour = new ChainMail();

            bool valArmourEquipped = thief.EquipToBody(chainArmour);

            Assert.IsFalse(valArmourEquipped, "TEST1: It is expected that the Armour Cannot be equipped");
            Assert.IsNull(thief.equippedToBody, "TEST2: It was expected that the armour is NOT equipped");
        }

        [TestMethod]
        public void TestEquipToBody_TryingToEquipItemThatEquipsToAHandToTheBody()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 10);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 8);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Thief thief = new Thief("Stickie", Race.Elf, dict, hp, xp);

            Sword sword = new Sword();

            bool valSwordEquipped = thief.EquipToBody(sword);

            Assert.IsFalse(valSwordEquipped, "TEST1: It is expected that the a thief cannot equip a shield");
            Assert.IsNull(thief.equippedToBody, "TEST2: It was expected that the shield is NOT equipped");
        }
    }
}
