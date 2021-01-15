using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dungeons_and_Dragons;
using System;
using System.Collections.Generic;
using System.Text;
using Dungeons_and_Dragons.InteractItems;

namespace Dungeons_and_Dragons_Test
{
    [TestClass]
    public class FighterTest
    {
        [TestMethod]
        public void SetFighterLevelTest()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Fighter fighter = new Fighter("Richard", Race.Human, dict, hp, xp);

            fighter.IncreaseExperiencePoints(0);

            Assert.AreEqual(1, fighter.currentLevel, "TEST1: The level is not as expected");

            fighter.IncreaseExperiencePoints(1999);

            Assert.AreEqual(1, fighter.currentLevel, "TEST2: The level is not as expected");

            fighter.IncreaseExperiencePoints(1);

            Assert.AreEqual(2, fighter.currentLevel, "TEST3: The level is not as expected");

            fighter.IncreaseExperiencePoints(1999);

            Assert.AreEqual(2, fighter.currentLevel, "TEST4: The level is not as expected");

            fighter.IncreaseExperiencePoints(1);

            Assert.AreEqual(3, fighter.currentLevel, "TEST5: The level is not as expected");
        }

        [TestMethod]
        public void TestEquipToHand_EquippingOneHandedWeaponToAnEmptyHand()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Fighter fighter = new Fighter("Richard", Race.Human, dict, hp, xp);

            Sword sword = new Sword();

            Assert.IsNull(fighter.equippedInRightHand, "TEST1: It was expected that nothing should be equipped to the fighter's right hand");

            bool val = fighter.EquipToHand(sword, Hand.Right);

            Assert.IsTrue(val, "TEST2: It was expected equipping the sword to the right hand should return true");
            Assert.AreEqual(sword, fighter.equippedInRightHand, "TEST3: It was expected that the sword should be equipped");
            Assert.IsNull(fighter.equippedInLeftHand, "TEST4: It was expected that the left hand is empty");
        }

        [TestMethod]
        public void TestEquipToHand_EquippingTwoHandedWeaponWhereBothHandsAreEmpty()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Fighter fighter = new Fighter("Richard", Race.Human, dict, hp, xp);

            TwoHandedSword sword = new TwoHandedSword();

            Assert.IsNull(fighter.equippedInRightHand, "TEST1: It was expected that nothing should be equipped to the fighter's right hand");
            Assert.IsNull(fighter.equippedInLeftHand, "TEST2: It was expected that nothing should be equipped to the fighter's left hand");

            bool val = fighter.EquipToHand(sword, Hand.Right);

            Assert.IsTrue(val, "TEST3: It was expected equipping the sword to the right hand should return true");
            Assert.AreEqual(sword, fighter.equippedInRightHand, "TEST4: It was expected that the sword should be equipped to the right hand");
            Assert.AreEqual(sword, fighter.equippedInLeftHand, "TEST5: It was expected that the sword should be equipped to the left hand");
        }

        [TestMethod]
        public void TestEquipToHand_EquippingOneHandedWeaponToAHandHoldingAOneHandedWeapon()
        {
            int expectedItemCountInInventoryAtStart = 0;
            int expectedItemCountInInventoryAfterWeaponSwap = 1;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Fighter fighter = new Fighter("Richard", Race.Human, dict, hp, xp);

            Sword sword = new Sword();
            Mace mace = new Mace();

            bool valSwordEquip = fighter.EquipToHand(sword, Hand.Right);

            Assert.IsTrue(valSwordEquip, "TEST1: It was expected equipping the sword to the right hand should return true");
            Assert.AreEqual(sword, fighter.equippedInRightHand, "TEST2: It was expected that the sword should be equipped");
            Assert.AreEqual(expectedItemCountInInventoryAtStart, fighter.inventory.Count,
                "TEST3: It was expected that the fighter's inventory was empty");

            bool valMaceEquip = fighter.EquipToHand(mace, Hand.Right);

            Assert.IsTrue(valMaceEquip, "TEST4: It was expected equipping the mace to the right hand should return true");
            Assert.AreEqual(mace, fighter.equippedInRightHand, "TEST5: It was expected that the mace should be equipped");
            Assert.AreEqual(expectedItemCountInInventoryAfterWeaponSwap, fighter.inventory.Count,
                "TEST6: It was expected that the fighter's inventory should contain 1 item");
            Assert.AreEqual(sword, fighter.inventory[0],
                "TEST7: It was expected that the sword should be the item in the fighter's inventory");
            Assert.IsNull(fighter.equippedInLeftHand, "TEST8: It was expected that the left hand is empty");
        }

        [TestMethod]
        public void TestEquipToHand_EquippingOneHandedWeaponToAnEmptyHandWhenTheOtherHandHoldsAOneHandedWeapon()
        {
            int expectedItemCountInInventory = 0;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Fighter fighter = new Fighter("Richard", Race.Human, dict, hp, xp);

            Sword sword = new Sword();
            Mace mace = new Mace();

            bool valSwordEquip = fighter.EquipToHand(sword, Hand.Right);

            Assert.IsTrue(valSwordEquip, "TEST1: It was expected equipping the sword to the right hand should return true");
            Assert.AreEqual(sword, fighter.equippedInRightHand, "TEST2: It was expected that the sword should be equipped");
            Assert.AreEqual(expectedItemCountInInventory, fighter.inventory.Count,
                "TEST3: It was expected that the fighter's inventory was empty");

            bool valMaceEquip = fighter.EquipToHand(mace, Hand.Left);

            Assert.IsTrue(valMaceEquip, "TEST4: It was expected equipping the mace to the left hand should return true");
            Assert.AreEqual(mace, fighter.equippedInLeftHand, "TEST5: It was expected that the mace should be equipped in the left hand");
            Assert.AreEqual(sword, fighter.equippedInRightHand, "TEST6: It was expected that the sword should be equipped in the right hand");
            Assert.AreEqual(expectedItemCountInInventory, fighter.inventory.Count,
                "TEST7: It was expected that the fighter's inventory was empty");
        }

        [TestMethod]
        public void TestEquipToHand_EquippingOneHandedWeaponWhenATwoHandedWeaponIsHeld()
        {
            int expectedItemCountInInventory = 0;
            int expectedItemCountInInventoryAfterTheSwap = 1;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Fighter fighter = new Fighter("Richard", Race.Human, dict, hp, xp);

            TwoHandedSword twoHandedSword = new TwoHandedSword();
            Mace mace = new Mace();

            bool valSwordEquip = fighter.EquipToHand(twoHandedSword, Hand.Right);

            Assert.IsTrue(valSwordEquip, "TEST1: It was expected equipping the two handed sword should return true");
            Assert.AreEqual(twoHandedSword, fighter.equippedInRightHand, "TEST2: It was expected that the sword should be equipped");
            Assert.AreEqual(twoHandedSword, fighter.equippedInLeftHand, "TEST3: It was expected that the sword should be equipped");
            Assert.AreEqual(expectedItemCountInInventory, fighter.inventory.Count,
                "TEST4: It was expected that the fighter's inventory was empty");

            bool valMaceEquip = fighter.EquipToHand(mace, Hand.Right);

            Assert.IsTrue(valMaceEquip, "TEST5: It was expected equipping the mace should return true");
            Assert.AreEqual(mace, fighter.equippedInRightHand, "TEST6: It was expected that the mace should be equipped in the right hand");
            Assert.IsNull(fighter.equippedInLeftHand, "TEST7: It was expected that the left hand should be empty");
            Assert.AreEqual(expectedItemCountInInventoryAfterTheSwap, fighter.inventory.Count,
                "TEST8: It was expected that the fighter's inventory should contain 1 item");
            Assert.AreEqual(twoHandedSword, fighter.inventory[0], "TEST9: It was expected that the 2 handed short should be in the inventory");
        }

        [TestMethod]
        public void TestEquipToHand_EquippingTwoHandWeaponWhenAOneHandedWeaponIsHeldInTheHandBeingEquippedTo()
        {
            int expectedItemCountInInventory = 0;
            int expectedItemCountInInventoryAfterTheSwap = 1;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Fighter fighter = new Fighter("Richard", Race.Human, dict, hp, xp);

            Mace mace = new Mace();
            TwoHandedSword twoHandedSword = new TwoHandedSword();

            bool valMaceEquip = fighter.EquipToHand(mace, Hand.Right);

            Assert.IsTrue(valMaceEquip, "TEST1: It was expected equipping the mace should return true");
            Assert.AreEqual(mace, fighter.equippedInRightHand, "TEST2: It was expected that the mace should be equipped to the right hand");
            Assert.IsNull(fighter.equippedInLeftHand, "TEST3: It was expected that the left hand is empty");
            Assert.AreEqual(expectedItemCountInInventory, fighter.inventory.Count,
                "TEST4: It was expected that the fighter's inventory was empty");

            bool valSwordEquip = fighter.EquipToHand(twoHandedSword, Hand.Right);

            Assert.IsTrue(valSwordEquip, "TEST5: It was expected equipping the two hand sword should return true");
            Assert.AreEqual(twoHandedSword, fighter.equippedInRightHand, "TEST6: It was expected that the two handed sword should be equipped in the right hand");
            Assert.AreEqual(twoHandedSword, fighter.equippedInLeftHand, "TEST7: It was expected that the two handed sword should be equipped in the left hand");
            Assert.AreEqual(expectedItemCountInInventoryAfterTheSwap, fighter.inventory.Count,
                "TEST8: It was expected that the fighter's inventory should contain 1 item");
            Assert.AreEqual(mace, fighter.inventory[0], "TEST9: It was expected that the mace should be in the inventory");
        }

        [TestMethod]
        public void TestEquipToHand_EquippingTwoHandWeaponWhenAOneHandedWeaponIsHeldInTheHandNotBeingEquippedTo()
        {
            int expectedItemCountInInventory = 0;
            int expectedItemCountInInventoryAfterTheSwap = 1;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Fighter fighter = new Fighter("Richard", Race.Human, dict, hp, xp);

            Mace mace = new Mace();
            TwoHandedSword twoHandedSword = new TwoHandedSword();

            bool valMaceEquip = fighter.EquipToHand(mace, Hand.Right);

            Assert.IsTrue(valMaceEquip, "TEST1: It was expected equipping the mace should return true");
            Assert.AreEqual(mace, fighter.equippedInRightHand, "TEST2: It was expected that the mace should be equipped to the right hand");
            Assert.IsNull(fighter.equippedInLeftHand, "TEST3: It was expected that the left hand is empty");
            Assert.AreEqual(expectedItemCountInInventory, fighter.inventory.Count,
                "TEST4: It was expected that the fighter's inventory was empty");

            bool valSwordEquip = fighter.EquipToHand(twoHandedSword, Hand.Left);

            Assert.IsTrue(valSwordEquip, "TEST5: It was expected equipping the two hand sword should return true");
            Assert.AreEqual(twoHandedSword, fighter.equippedInRightHand, "TEST6: It was expected that the two handed sword should be equipped in the right hand");
            Assert.AreEqual(twoHandedSword, fighter.equippedInLeftHand, "TEST7: It was expected that the two handed sword should be equipped in the left hand");
            Assert.AreEqual(expectedItemCountInInventoryAfterTheSwap, fighter.inventory.Count,
                "TEST8: It was expected that the fighter's inventory should contain 1 item");
            Assert.AreEqual(mace, fighter.inventory[0], "TEST9: It was expected that the mace should be in the inventory");
        }

        [TestMethod]
        public void TestEquipToHand_EquippingTwoHandWeaponWhenBothHandsAreHoldingWeapons()
        {
            int expectedItemCountInInventory = 0;
            int expectedItemCountInInventoryAfterTheSwap = 2;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Fighter fighter = new Fighter("Richard", Race.Human, dict, hp, xp);

            Mace mace = new Mace();
            Spear spear = new Spear();
            TwoHandedSword twoHandedSword = new TwoHandedSword();

            bool valMaceEquip = fighter.EquipToHand(mace, Hand.Right);
            bool valSpearEquip = fighter.EquipToHand(spear, Hand.Left);

            Assert.IsTrue(valMaceEquip, "TEST1: It was expected equipping the mace to the right hand should return true");
            Assert.AreEqual(mace, fighter.equippedInRightHand, "TEST2: It was expected that the mace should be equipped to the right hand");
            Assert.IsTrue(valSpearEquip, "TEST3: It was expected equipping the spear to the left hand should return true");
            Assert.AreEqual(spear, fighter.equippedInLeftHand, "TEST4: It was expected that the spear should be equipped to the left hand");
            Assert.AreEqual(expectedItemCountInInventory, fighter.inventory.Count,
                "TEST5: It was expected that the fighter's inventory was empty");

            bool valSwordEquip = fighter.EquipToHand(twoHandedSword, Hand.Left);

            Assert.IsTrue(valSwordEquip, "TEST5: It was expected equipping the two hand sword should return true");
            Assert.AreEqual(twoHandedSword, fighter.equippedInRightHand, "TEST6: It was expected that the two handed sword should be equipped in the right hand");
            Assert.AreEqual(twoHandedSword, fighter.equippedInLeftHand, "TEST7: It was expected that the two handed sword should be equipped in the left hand");
            Assert.AreEqual(expectedItemCountInInventoryAfterTheSwap, fighter.inventory.Count,
                "TEST8: It was expected that the fighter's inventory should contain 2 items");
            Assert.AreEqual(mace, fighter.inventory[0], "TEST9: It was expected that the mace should be in the inventory");
            Assert.AreEqual(spear, fighter.inventory[1], "TEST10: It was expected that the spear should be in the inventory");
        }

        [TestMethod]
        public void TestEquipToHand_EquipAShieldToAnEmptyHand()
        {
            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Fighter fighter = new Fighter("Richard", Race.Human, dict, hp, xp);

            Shield shield = new Shield();

            bool valShieldEquipped = fighter.EquipToHand(shield, Hand.Right);

            Assert.IsTrue(valShieldEquipped, "TEST1: It was expected that equipping the shield should return true");
            Assert.AreEqual(shield, fighter.equippedInRightHand, "TEST2: It was expected that the shield should be equipped to the fighter's right hand");
        }

        //for more equipping armour tests see thief
        public void TestEquipToBody_EquippingArmourWhenArmourIsAlreadyWorn()
        {
            int expectedItemCountInInventory = 0;
            int expectedItemCountInInventoryAfterTheSwap = 1;

            Dictionary<Dungeons_and_Dragons.Attribute, int> dict = new Dictionary<Dungeons_and_Dragons.Attribute, int>();
            dict.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            dict.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            dict.Add(Dungeons_and_Dragons.Attribute.Intelligence, 3);
            dict.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);
            dict.Add(Dungeons_and_Dragons.Attribute.Constitution, 17);
            dict.Add(Dungeons_and_Dragons.Attribute.Charisma, 9);
            int xp = 0;
            int hp = 3;
            Fighter fighter = new Fighter("Richard", Race.Human, dict, hp, xp);

            LeatherArmour leatherArmour = new LeatherArmour();
            ChainMail chainMail = new ChainMail();

            bool valLeatherArmourEquipped = fighter.EquipToBody(leatherArmour);

            Assert.IsTrue(valLeatherArmourEquipped, "TEST1: It was expected that equipping the leather armour should return true");
            Assert.AreEqual(leatherArmour, fighter.equippedToBody, "TEST2: It was expected that the leather armour should be equipped to the body");
            Assert.AreEqual(expectedItemCountInInventory, fighter.inventory.Count, "TEST3: It was expected that the fighter's inventory should be empty");

            bool valChainArmourEquipped = fighter.EquipToBody(chainMail);

            Assert.IsTrue(valChainArmourEquipped, "TEST4: It was expected that equipping the chain armour should return true");
            Assert.AreEqual(chainMail, fighter.equippedToBody, "TEST5: It was expected that the chain armour should be equipped to the body");
            Assert.AreEqual(expectedItemCountInInventoryAfterTheSwap, fighter.inventory.Count, 
                "TEST6: It was expected that the fighter's inventory should contain a single item");
            Assert.AreEqual(leatherArmour, fighter.inventory[0],
                "TEST7: It was expected that the fighter's inventory should contain the leather armour");
        }
    }
}
