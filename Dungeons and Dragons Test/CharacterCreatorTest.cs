using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dungeons_and_Dragons;
using System.Collections.Generic;

namespace Dungeons_and_Dragons_Test
{
    [TestClass]
    public class CharacterCreatorTest
    {
        [TestMethod]
        public void TestSetClass_WhereClassIsFighter()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Constitution, 13);
            cc.SetClass(ClassType.Fighter);

            Assert.AreEqual(ClassType.Fighter, cc.classType, "TEST1: The race returned was not as expected");
            Assert.AreEqual(Dungeons_and_Dragons.Attribute.Strength, cc.primeRequisite, "TEST2: The prime requisite returned was not as expected");
        }

        [TestMethod]
        public void TestSetClass_WhereClassIsThief()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Constitution, 7);
            cc.SetClass(ClassType.Thief);


            Assert.AreEqual(ClassType.Thief, cc.classType, "TEST1: The race returned was not as expected");
            Assert.AreEqual(Dungeons_and_Dragons.Attribute.Dexterity, cc.primeRequisite, "TEST2: The prime requisite returned was not as expected");
        }

        [TestMethod]
        public void TestSetClass_WhereClassIsMagicUser()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Constitution, 18);
            cc.SetClass(ClassType.MagicUser);


            Assert.AreEqual(ClassType.MagicUser, cc.classType, "TEST1: The race returned was not as expected");
            Assert.AreEqual(Dungeons_and_Dragons.Attribute.Intelligence, cc.primeRequisite, "TEST2: The prime requisite returned was not as expected");
        }

        [TestMethod]
        public void TestSetClass_WhereClassIsCleric()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Constitution, 3);
            cc.SetClass(ClassType.Cleric);

            Assert.AreEqual(ClassType.Cleric, cc.classType, "TEST1: The race returned was not as expected");
            Assert.AreEqual(Dungeons_and_Dragons.Attribute.Wisdom, cc.primeRequisite, "TEST2: The prime requisite returned was not as expected");
        }

        [TestMethod]
        public void TestSetRaceToDwarf()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.setRace(Race.Dwarf);
            Assert.AreEqual(Race.Dwarf, cc.characterRace, "The race returned was not as expected");
        }

        [TestMethod]
        public void TestSetNameToBob()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.setCharacterName("Bob");
            Assert.AreEqual("Bob", cc.characterName, "The name was not as expected");
        }

        [TestMethod]
        public void TestRollAttributes()
        {
            int numberOfAttributes = 6;
            CharacterCreator cc = new CharacterCreator();

            cc.RollAttibutes();

            Assert.AreEqual(numberOfAttributes, cc.originalAttributes.Count, "TEST1: The number of entries in OriginalAttributes was not as expected");
            Assert.IsTrue(cc.originalAttributes.ContainsKey(Dungeons_and_Dragons.Attribute.Strength), "Test2: OriginalAttributes does not contain the attribute Strength");
            Assert.IsTrue(cc.originalAttributes.ContainsKey(Dungeons_and_Dragons.Attribute.Dexterity), "TEST3: OriginalAttributes does not contain the attribute Dexterity");
            Assert.IsTrue(cc.originalAttributes.ContainsKey(Dungeons_and_Dragons.Attribute.Intelligence), "TEST4: OriginalAttributes does not contain the attribute Intelligence");
            Assert.IsTrue(cc.originalAttributes.ContainsKey(Dungeons_and_Dragons.Attribute.Wisdom), "TEST5: OriginalAttributes does not contain the attribute Wisdom");
            Assert.IsTrue(cc.originalAttributes.ContainsKey(Dungeons_and_Dragons.Attribute.Constitution), "TEST6: OriginalAttributes does not contain the attribute Constitution");
            Assert.IsTrue(cc.originalAttributes.ContainsKey(Dungeons_and_Dragons.Attribute.Charisma), "TEST7: OriginalAttributes does not contain the attribute Charisma");
        }

        [TestMethod]
        public void TestSetAmendedAttributesToOriginal()
        {
            CharacterCreator cc = new CharacterCreator();
            Assert.AreEqual(0, cc.amendedAttributes.Count, "TEST1: The number of entries in AmendedAttributes is not as expected");
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Strength, 7);

            cc.SetAmendedAttributesToOriginal();

            Assert.AreEqual(1, cc.amendedAttributes.Count, "TEST2: The number of entries in AmendedAttributes is not as expected");
            Assert.IsTrue(cc.amendedAttributes.ContainsKey(Dungeons_and_Dragons.Attribute.Strength), "TEST3: AmendedAttributes does not contain the attribute Strength");
            Assert.AreEqual(7, cc.amendedAttributes[Dungeons_and_Dragons.Attribute.Strength], "TEST4: The Strength Value in AmendedAttributes is not as expected");
        }

        [TestMethod]
        public void TestSetOriginalAttributesToAmended()
        {
            CharacterCreator cc = new CharacterCreator();
            Assert.AreEqual(0, cc.originalAttributes.Count, "TEST1: The number of entries in OriginalAttributes is not as expected");
            cc.amendedAttributes.Add(Dungeons_and_Dragons.Attribute.Intelligence, 12);
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Wisdom, 14);
            Assert.AreEqual(1, cc.originalAttributes.Count, "TEST2: The number of entries in OriginalAttributes is not as expected");

            //should clear the entries in original and replace them with those in amended
            cc.SetOriginalAttributesToAmended();

            Assert.AreEqual(1, cc.originalAttributes.Count, "TEST3: The number of entries in OriginalAttributes is not as expected");
            Assert.IsTrue(!cc.originalAttributes.ContainsKey(Dungeons_and_Dragons.Attribute.Wisdom), "TEST4: OriginalAttributes should NOT contain the Attribute Wisdom");
            Assert.IsTrue(cc.originalAttributes.ContainsKey(Dungeons_and_Dragons.Attribute.Intelligence), "TEST5: OriginalAttributes should contain the Attribute Intelligence");
            Assert.AreEqual(12, cc.originalAttributes[Dungeons_and_Dragons.Attribute.Intelligence], "TEST6: The Intelligence Value in OringalAttributes is not as expected");
        }

        [TestMethod]
        public void TestGetSuggestedClass_WhereThereIsASingleBestClass()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Strength, 12);
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Intelligence, 14);
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Wisdom, 9);

            string val = cc.GetSuggestedClass();

            Assert.AreEqual("Thief", val, "TEST1: The suggested Class is not as expected");
        }

        [TestMethod]
        public void TestGetSuggestedClass_WhereThereIsAreMultipleBestClasses()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Strength, 5);
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Dexterity, 14);
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Intelligence, 14);
            cc.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Wisdom, 13);

            string valForcc = cc.GetSuggestedClass();

            //test where 2 classes are best to ensure 'or' appears correctly and that no ',' appear
            Assert.AreEqual("Thief or Magic-User", valForcc, "TEST1: The suggested Classes were not as expected");

            CharacterCreator cc1 = new CharacterCreator();
            cc1.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Strength, 13);
            cc1.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Dexterity, 13);
            cc1.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Intelligence, 13);
            cc1.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Wisdom, 13);

            string valForcc1 = cc1.GetSuggestedClass();

            //test were all classes are best to ensure 'or' and ',' appear correctly 
            Assert.AreEqual("Fighter, Thief, Magic-User or Cleric", valForcc1, "TEST2: The suggested Classes were not as expected");
        }

        [TestMethod]
        public void TestIncreaseAttribute_WhereThereAreEnoughUnassignedPointsAndTheAttributeIsNotSetTo18()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.amendedAttributes.Add(Dungeons_and_Dragons.Attribute.Strength, 11);
            cc.AlterUnassignedPoints(2);

            var ret = cc.IncreaseAttribute(Dungeons_and_Dragons.Attribute.Strength);

            Assert.IsTrue(String.IsNullOrEmpty(ret), "TEST1: The returned value was not as expected");
            Assert.AreEqual(12, cc.amendedAttributes[Dungeons_and_Dragons.Attribute.Strength], "TEST2: The value held by the Attribute Strenght was not as expected");
            Assert.AreEqual(0, cc.unassignedPoints, "TEST3: The number of unassgined points was not as expected");
        }

        [TestMethod]
        public void TestIncreaseAttribute_WhereThereAreNOTEnoughUnassignedPointsAndTheAttributeIsNotSetTo18()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.amendedAttributes.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);
            cc.AlterUnassignedPoints(1);

            var ret = cc.IncreaseAttribute(Dungeons_and_Dragons.Attribute.Wisdom);

            Assert.AreEqual("You need at least 2 unassigned points to raise an attribute by 1 point", ret, "TEST1: The returned value was not as expected");
            Assert.AreEqual(12, cc.amendedAttributes[Dungeons_and_Dragons.Attribute.Wisdom], "TEST2: The value held by the Attribute Wisdom was not as expected");
            Assert.AreEqual(1, cc.unassignedPoints, "TEST3: The number of unassgined points was not as expected");
        }

        [TestMethod]
        public void TestIncreaseAttribute_WhereThereAreEnoughUnassignedPointsAndTheAttributeIsSetTo18()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.amendedAttributes.Add(Dungeons_and_Dragons.Attribute.Intelligence, 18);
            cc.AlterUnassignedPoints(2);

            var ret = cc.IncreaseAttribute(Dungeons_and_Dragons.Attribute.Intelligence);

            Assert.AreEqual("It is not possible to increase an attribute above 18", ret, "TEST1: The returned value was not as expected");
            Assert.AreEqual(18, cc.amendedAttributes[Dungeons_and_Dragons.Attribute.Intelligence], "TEST2: The value held by the Attribute Intelligence was not as expected");
            Assert.AreEqual(2, cc.unassignedPoints, "TEST3: The number of unassgined points was not as expected");
        }

        [TestMethod]
        public void TestIncreaseAttribute_WhereThereAreNOTEnoughUnassignedPointsAndTheAttributeIsSetTo18()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.amendedAttributes.Add(Dungeons_and_Dragons.Attribute.Dexterity, 18);
            cc.AlterUnassignedPoints(1);

            var ret = cc.IncreaseAttribute(Dungeons_and_Dragons.Attribute.Dexterity);

            Assert.AreEqual("You need at least 2 unassigned points to raise an attribute by 1 point", ret, "TEST1: The returned value was not as expected");
            Assert.AreEqual(18, cc.amendedAttributes[Dungeons_and_Dragons.Attribute.Dexterity], "TEST2: The value held by the Attribute Dexterity was not as expected");
            Assert.AreEqual(1, cc.unassignedPoints, "TEST3: The number of unassgined points was not as expected");
        }

        [TestMethod]
        public void TestDecreaseAttribute_WhereTheAttributeIsNotSetTo3()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.amendedAttributes.Add(Dungeons_and_Dragons.Attribute.Constitution, 12);

            var ret = cc.DecreaseAttribute(Dungeons_and_Dragons.Attribute.Constitution);

            Assert.IsTrue(String.IsNullOrEmpty(ret), "TEST1: The returned value was not as expected");
            Assert.AreEqual(11, cc.amendedAttributes[Dungeons_and_Dragons.Attribute.Constitution], "TEST2: The value held by the Attribute Constitution was not as expected");
            Assert.AreEqual(1, cc.unassignedPoints, "TEST3: The number of unassgined points was not as expected");
        }

        [TestMethod]
        public void TestDecreaseAttribute_WhereTheAttributeIsSetTo3()
        {
            CharacterCreator cc = new CharacterCreator();
            cc.amendedAttributes.Add(Dungeons_and_Dragons.Attribute.Charisma, 3);

            var ret = cc.DecreaseAttribute(Dungeons_and_Dragons.Attribute.Charisma);

            Assert.AreEqual("It is not possible to decrease an attribute below 3", ret, "TEST1: The returned value was not as expected");
            Assert.AreEqual(3, cc.amendedAttributes[Dungeons_and_Dragons.Attribute.Charisma], "TEST2: The value held by the Attribute Charisma was not as expected");
            Assert.AreEqual(0, cc.unassignedPoints, "TEST3: The number of unassgined points was not as expected");
        }

        [TestMethod]
        public void TestAlterUnassignedPoints()
        {
            CharacterCreator cc = new CharacterCreator();
            Assert.AreEqual(0, cc.unassignedPoints, "TEST1: The number of Unassigned Points is not as expected");

            cc.AlterUnassignedPoints(3);
            Assert.AreEqual(3, cc.unassignedPoints, "TEST2: The number of Unassigned Points is not as expected");

            cc.AlterUnassignedPoints(-1);
            Assert.AreEqual(2, cc.unassignedPoints, "TEST3: The number of Unassigned Points is not as expected");

            cc.AlterUnassignedPoints(-1 * cc.unassignedPoints);
            Assert.AreEqual(0, cc.unassignedPoints, "TEST4: The number of Unassigned Points is not as expected");
        }

        [TestMethod]
        public void TestUpdateStrengthBonusText_WhereStrengthBonusIsMinus3()
        {
            CharacterCreator cc = new CharacterCreator();

            var ret = cc.UpdateStrengthBonusText(3);

            Assert.AreEqual(-3, cc.strBonus_ToHit_Damage_ToOpenDoor, "TEST1: The strength bonus is not as expected");
            Assert.AreEqual("-3 to hit, damage and opening doors", ret, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateStrengthBonusText_WhereStrengthBonusIsMinus2()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateStrengthBonusText(4);

            Assert.AreEqual(-2, cc1.strBonus_ToHit_Damage_ToOpenDoor, "TEST1: The strength bonus is not as expected");
            Assert.AreEqual("-2 to hit, damage and opening doors", retCc1, "TEST2: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateStrengthBonusText(5);

            Assert.AreEqual(-2, cc2.strBonus_ToHit_Damage_ToOpenDoor, "TEST3: The strength bonus is not as expected");
            Assert.AreEqual("-2 to hit, damage and opening doors", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateStrengthBonusText_WhereStrengthBonusIsMinus1()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateStrengthBonusText(6);

            Assert.AreEqual(-1, cc1.strBonus_ToHit_Damage_ToOpenDoor, "TEST1: The strength bonus is not as expected");
            Assert.AreEqual("-1 to hit, damage and opening doors", retCc1, "TEST2: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateStrengthBonusText(8);

            Assert.AreEqual(-1, cc2.strBonus_ToHit_Damage_ToOpenDoor, "TEST3: The strength bonus is not as expected");
            Assert.AreEqual("-1 to hit, damage and opening doors", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateStrengthBonusText_WhereStrengthBonusIsZero()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateStrengthBonusText(9);

            Assert.AreEqual(0, cc1.strBonus_ToHit_Damage_ToOpenDoor, "TEST1: The strength bonus is not as expected");
            Assert.AreEqual("No adjustments due to Strength", retCc1, "TEST2: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateStrengthBonusText(12);

            Assert.AreEqual(0, cc2.strBonus_ToHit_Damage_ToOpenDoor, "TEST3: The strength bonus is not as expected");
            Assert.AreEqual("No adjustments due to Strength", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateStrengthBonusText_WhereStrengthBonusIsPlus1()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateStrengthBonusText(13);

            Assert.AreEqual(+1, cc1.strBonus_ToHit_Damage_ToOpenDoor, "TEST1: The strength bonus is not as expected");
            Assert.AreEqual("+1 to hit, damage and opening doors", retCc1, "TEST2: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateStrengthBonusText(15);

            Assert.AreEqual(+1, cc2.strBonus_ToHit_Damage_ToOpenDoor, "TEST3: The strength bonus is not as expected");
            Assert.AreEqual("+1 to hit, damage and opening doors", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateStrengthBonusText_WhereStrengthBonusIsPlus2()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateStrengthBonusText(16);

            Assert.AreEqual(+2, cc1.strBonus_ToHit_Damage_ToOpenDoor, "TEST1: The strength bonus is not as expected");
            Assert.AreEqual("+2 to hit, damage and opening doors", retCc1, "TEST2: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateStrengthBonusText(17);

            Assert.AreEqual(+2, cc2.strBonus_ToHit_Damage_ToOpenDoor, "TEST3: The strength bonus is not as expected");
            Assert.AreEqual("+2 to hit, damage and opening doors", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateStrengthBonusText_WhereStrengthBonusIsPlus3()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateStrengthBonusText(18);

            Assert.AreEqual(+3, cc1.strBonus_ToHit_Damage_ToOpenDoor, "TEST1: The strength bonus is not as expected");
            Assert.AreEqual("+3 to hit, damage and opening doors", retCc1, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateDexterityText_WhereDexterityBonusIsMinus3()
        {
            CharacterCreator cc = new CharacterCreator();

            var ret = cc.UpdateDexterityBonusText(3);

            Assert.AreEqual(-3, cc.dexBonus_ToHitMissiles, "TEST1: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(3, cc.dexBonus_AcAdjustment, "TEST2: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(-2, cc.dexBonus_InitiativeAdjustment, "TEST3: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("-3 missile 'to hit' rolls, +3 Armour Class Adjustment, -2 Initiative Adjustment", ret, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateDexterityText_WhereDexterityBonusIsMinus2()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateDexterityBonusText(4);

            Assert.AreEqual(-2, cc1.dexBonus_ToHitMissiles, "TEST1: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(2, cc1.dexBonus_AcAdjustment, "TEST2: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(-1, cc1.dexBonus_InitiativeAdjustment, "TEST3: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("-2 missile 'to hit' rolls, +2 Armour Class Adjustment, -1 Initiative Adjustment", retCc1, "TEST4: The returned string is not as expected");

            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateDexterityBonusText(5);

            Assert.AreEqual(-2, cc2.dexBonus_ToHitMissiles, "TEST5: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(2, cc2.dexBonus_AcAdjustment, "TEST6: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(-1, cc2.dexBonus_InitiativeAdjustment, "TEST7: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("-2 missile 'to hit' rolls, +2 Armour Class Adjustment, -1 Initiative Adjustment", retCc2, "TEST8: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateDexterityText_WhereDexterityBonusIsMinus1()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateDexterityBonusText(6);

            Assert.AreEqual(-1, cc1.dexBonus_ToHitMissiles, "TEST1: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(1, cc1.dexBonus_AcAdjustment, "TEST2: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(-1, cc1.dexBonus_InitiativeAdjustment, "TEST3: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("-1 missile 'to hit' rolls, +1 Armour Class Adjustment, -1 Initiative Adjustment", retCc1, "TEST4: The returned string is not as expected");

            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateDexterityBonusText(8);

            Assert.AreEqual(-1, cc2.dexBonus_ToHitMissiles, "TEST5: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(1, cc2.dexBonus_AcAdjustment, "TEST6: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(-1, cc2.dexBonus_InitiativeAdjustment, "TEST7: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("-1 missile 'to hit' rolls, +1 Armour Class Adjustment, -1 Initiative Adjustment", retCc2, "TEST8: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateDexterityText_WhereDexterityBonusIsZero()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateDexterityBonusText(9);

            Assert.AreEqual(0, cc1.dexBonus_ToHitMissiles, "TEST1: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(0, cc1.dexBonus_AcAdjustment, "TEST2: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(0, cc1.dexBonus_InitiativeAdjustment, "TEST3: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("No adjustments due to Dexterity", retCc1, "TEST4: The returned string is not as expected");

            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateDexterityBonusText(12);

            Assert.AreEqual(0, cc2.dexBonus_ToHitMissiles, "TEST5: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(0, cc2.dexBonus_AcAdjustment, "TEST6: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(0, cc2.dexBonus_InitiativeAdjustment, "TEST7: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("No adjustments due to Dexterity", retCc2, "TEST8: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateDexterityText_WhereDexterityBonusIsPlus1()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateDexterityBonusText(13);

            Assert.AreEqual(1, cc1.dexBonus_ToHitMissiles, "TEST1: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(-1, cc1.dexBonus_AcAdjustment, "TEST2: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(1, cc1.dexBonus_InitiativeAdjustment, "TEST3: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("+1 missile 'to hit' rolls, -1 Armour Class Adjustment, +1 Initiative Adjustment", retCc1, "TEST4: The returned string is not as expected");

            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateDexterityBonusText(15);

            Assert.AreEqual(1, cc2.dexBonus_ToHitMissiles, "TEST5: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(-1, cc2.dexBonus_AcAdjustment, "TEST6: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(1, cc2.dexBonus_InitiativeAdjustment, "TEST7: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("+1 missile 'to hit' rolls, -1 Armour Class Adjustment, +1 Initiative Adjustment", retCc2, "TEST8: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateDexterityText_WhereDexterityBonusIsPlus2()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateDexterityBonusText(16);

            Assert.AreEqual(2, cc1.dexBonus_ToHitMissiles, "TEST1: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(-2, cc1.dexBonus_AcAdjustment, "TEST2: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(1, cc1.dexBonus_InitiativeAdjustment, "TEST3: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("+2 missile 'to hit' rolls, -2 Armour Class Adjustment, +1 Initiative Adjustment", retCc1, "TEST4: The returned string is not as expected");

            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateDexterityBonusText(17);

            Assert.AreEqual(2, cc2.dexBonus_ToHitMissiles, "TEST5: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(-2, cc2.dexBonus_AcAdjustment, "TEST6: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(1, cc2.dexBonus_InitiativeAdjustment, "TEST7: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("+2 missile 'to hit' rolls, -2 Armour Class Adjustment, +1 Initiative Adjustment", retCc2, "TEST8: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateDexterityText_WhereDexterityBonusIsPlus3()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateDexterityBonusText(18);

            Assert.AreEqual(3, cc1.dexBonus_ToHitMissiles, "TEST1: The Dexterity bonus for Missile 'To Hit' is not as expected");
            Assert.AreEqual(-3, cc1.dexBonus_AcAdjustment, "TEST2: The Dexterity bonus for Armour Class Adjustment is not as expected");
            Assert.AreEqual(2, cc1.dexBonus_InitiativeAdjustment, "TEST3: The Dexterity bonus for Initiative is not as expected");
            Assert.AreEqual("+3 missile 'to hit' rolls, -3 Armour Class Adjustment, +2 Initiative Adjustment", retCc1, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateIntelligenceBonusText_WhereIntelligenceBonusIsMinus3()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateIntelligenceBonusText(3);

            Assert.AreEqual("Has trouble with speaking, cannot read or write", retCc1, "The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateIntelligenceBonusText_WhereIntelligenceBonusIsMinus2()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateIntelligenceBonusText(4);

            Assert.AreEqual("Cannot read or write Common", retCc1, "TEST1: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateIntelligenceBonusText(5);

            Assert.AreEqual("Cannot read or write Common", retCc2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateIntelligenceBonusText_WhereIntelligenceBonusIsMinus1()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateIntelligenceBonusText(6);

            Assert.AreEqual("Can write simple Common words", retCc1, "TEST1: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateIntelligenceBonusText(8);

            Assert.AreEqual("Can write simple Common words", retCc2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateIntelligenceBonusText_WhereIntelligenceBonusIsZero()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateIntelligenceBonusText(9);

            Assert.AreEqual("Reads and writes native languages, usually 2", retCc1, "TEST1: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateIntelligenceBonusText(12);

            Assert.AreEqual("Reads and writes native languages, usually 2", retCc2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateIntelligenceBonusText_WhereIntelligenceBonusIsPlus1()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateIntelligenceBonusText(13);

            Assert.AreEqual("Reads and writes native languages, usually 2, +1 extra language", retCc1, "TEST1: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateIntelligenceBonusText(15);

            Assert.AreEqual("Reads and writes native languages, usually 2, +1 extra language", retCc2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateIntelligenceBonusText_WhereIntelligenceBonusIsPlus2()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateIntelligenceBonusText(16);

            Assert.AreEqual("Reads and writes native languages, usually 2, +2 extra language", retCc1, "TEST1: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateIntelligenceBonusText(17);

            Assert.AreEqual("Reads and writes native languages, usually 2, +2 extra language", retCc2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateIntelligenceBonusText_WhereIntelligenceBonusIsPlus3()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateIntelligenceBonusText(18);

            Assert.AreEqual("Reads and writes native languages, usually 2, +3 extra language", retCc1, "The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateWisdomText_WhereWisdomBonusIsMinus3()
        {
            CharacterCreator cc = new CharacterCreator();

            var ret = cc.UpdateWisdomBonusText(3);

            Assert.AreEqual(-3, cc.wisBonus_MagicBasedSavingThrowAdjustment, "TEST1: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("-3 on magic based saving throws", ret, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateWisdomText_WhereWisdomBonusIsMinus2()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateWisdomBonusText(4);

            Assert.AreEqual(-2, cc1.wisBonus_MagicBasedSavingThrowAdjustment, "TEST1: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("-2 on magic based saving throws", retCc1, "TEST2: The returned string is not as expected");

            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateWisdomBonusText(5);

            Assert.AreEqual(-2, cc2.wisBonus_MagicBasedSavingThrowAdjustment, "TEST3: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("-2 on magic based saving throws", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateWisdomText_WhereWisdomBonusIsMinus1()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateWisdomBonusText(6);

            Assert.AreEqual(-1, cc1.wisBonus_MagicBasedSavingThrowAdjustment, "TEST1: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("-1 on magic based saving throws", retCc1, "TEST2: The returned string is not as expected");

            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateWisdomBonusText(8);

            Assert.AreEqual(-1, cc2.wisBonus_MagicBasedSavingThrowAdjustment, "TEST3: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("-1 on magic based saving throws", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateWisdomText_WhereWisdomBonusIsZero()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateWisdomBonusText(9);

            Assert.AreEqual(0, cc1.wisBonus_MagicBasedSavingThrowAdjustment, "TEST1: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("No adjustments due to Wisdom", retCc1, "TEST2: The returned string is not as expected");

            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateWisdomBonusText(12);

            Assert.AreEqual(0, cc2.wisBonus_MagicBasedSavingThrowAdjustment, "TEST3: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("No adjustments due to Wisdom", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateWisdomText_WhereWisdomBonusIsPlus1()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateWisdomBonusText(13);

            Assert.AreEqual(1, cc1.wisBonus_MagicBasedSavingThrowAdjustment, "TEST1: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("+1 on magic based saving throws", retCc1, "TEST2: The returned string is not as expected");

            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateWisdomBonusText(15);

            Assert.AreEqual(1, cc2.wisBonus_MagicBasedSavingThrowAdjustment, "TEST3: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("+1 on magic based saving throws", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateWisdomText_WhereWisdomBonusIsPlus2()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateWisdomBonusText(16);

            Assert.AreEqual(2, cc1.wisBonus_MagicBasedSavingThrowAdjustment, "TEST1: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("+2 on magic based saving throws", retCc1, "TEST2: The returned string is not as expected");

            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateWisdomBonusText(17);

            Assert.AreEqual(2, cc2.wisBonus_MagicBasedSavingThrowAdjustment, "TEST3: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("+2 on magic based saving throws", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateWisdomText_WhereWisdomBonusIsPlus3()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateWisdomBonusText(18);

            Assert.AreEqual(3, cc1.wisBonus_MagicBasedSavingThrowAdjustment, "TEST1: The Wisdom bonus for Magic Based Saving throws is not as expected");
            Assert.AreEqual("+3 on magic based saving throws", retCc1, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateConstitutionBonusText_WhereConstitutionBonusIsMinus3()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateConstitutionBonusText(3);

            Assert.AreEqual(-3, cc1.conBonus_HitPointAdjustment, "TEST1: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("-3 points per hit dice", retCc1, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateConstitutionBonusText_WhereConstitutionBonusIsMinus2()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateConstitutionBonusText(4);

            Assert.AreEqual(-2, cc1.conBonus_HitPointAdjustment, "TEST1: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("-2 points per hit dice", retCc1, "TEST2: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateConstitutionBonusText(5);

            Assert.AreEqual(-2, cc2.conBonus_HitPointAdjustment, "TEST3: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("-2 points per hit dice", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateConstitutionBonusText_WhereConstitutionBonusIsMinus1()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateConstitutionBonusText(6);

            Assert.AreEqual(-1, cc1.conBonus_HitPointAdjustment, "TEST1: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("-1 points per hit dice", retCc1, "TEST2: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateConstitutionBonusText(8);

            Assert.AreEqual(-1, cc2.conBonus_HitPointAdjustment, "TEST3: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("-1 points per hit dice", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateConstitutionBonusText_WhereConstitutionBonusZero()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateConstitutionBonusText(9);

            Assert.AreEqual(0, cc1.conBonus_HitPointAdjustment, "TEST1: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("No adjustments due to Constitution", retCc1, "TEST2: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateConstitutionBonusText(12);

            Assert.AreEqual(0, cc2.conBonus_HitPointAdjustment, "TEST3: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("No adjustments due to Constitution", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateConstitutionBonusText_WhereConstitutionBonusPlus1()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateConstitutionBonusText(13);

            Assert.AreEqual(1, cc1.conBonus_HitPointAdjustment, "TEST1: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("+1 points per hit dice", retCc1, "TEST2: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateConstitutionBonusText(15);

            Assert.AreEqual(1, cc2.conBonus_HitPointAdjustment, "TEST3: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("+1 points per hit dice", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateConstitutionBonusText_WhereConstitutionBonusPlus2()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateConstitutionBonusText(16);

            Assert.AreEqual(2, cc1.conBonus_HitPointAdjustment, "TEST1: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("+2 points per hit dice", retCc1, "TEST2: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateConstitutionBonusText(17);

            Assert.AreEqual(2, cc2.conBonus_HitPointAdjustment, "TEST3: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("+2 points per hit dice", retCc2, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateConstitutionBonusText_WhereConstitutionBonusPlus3()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateConstitutionBonusText(18);

            Assert.AreEqual(3, cc1.conBonus_HitPointAdjustment, "TEST1: The Constitution bonus to Hit Point adjustment is not as expected");
            Assert.AreEqual("+3 points per hit dice", retCc1, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateCharismaBonusText_WhereCharismaBonusAllows1Retainer()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateCharismaBonusText(3);

            Assert.AreEqual(-2, cc1.chaBonus_ReactionAdjustment, "TEST1: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(1, cc1.chaBonus_NoOfRetainers, "TEST2: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(4, cc1.chaBonus_RetainerMorale, "TEST3: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("-2 to adjustment to reactions, maximum numbers of retainers 1" +
                    Environment.NewLine + "morale of retainers 4", retCc1, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateCharismaBonusText_WhereCharismaBonusAllows2Retainer()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateCharismaBonusText(4);

            Assert.AreEqual(-1, cc1.chaBonus_ReactionAdjustment, "TEST1: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(2, cc1.chaBonus_NoOfRetainers, "TEST2: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(5, cc1.chaBonus_RetainerMorale, "TEST3: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("-1 to adjustment to reactions, maximum numbers of retainers 2" +
                    Environment.NewLine + "morale of retainers 5", retCc1, "TEST4: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateCharismaBonusText(5);

            Assert.AreEqual(-1, cc2.chaBonus_ReactionAdjustment, "TEST5: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(2, cc2.chaBonus_NoOfRetainers, "TEST6: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(5, cc2.chaBonus_RetainerMorale, "TEST7: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("-1 to adjustment to reactions, maximum numbers of retainers 2" +
                    Environment.NewLine + "morale of retainers 5", retCc2, "TEST8: The returned string is not as expected");

        }

        [TestMethod]
        public void TestUpdateCharismaBonusText_WhereCharismaBonusAllows3Retainer()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateCharismaBonusText(6);

            Assert.AreEqual(-1, cc1.chaBonus_ReactionAdjustment, "TEST1: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(3, cc1.chaBonus_NoOfRetainers, "TEST2: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(6, cc1.chaBonus_RetainerMorale, "TEST3: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("-1 to adjustment to reactions, maximum numbers of retainers 3" +
                    Environment.NewLine + "morale of retainers 6", retCc1, "TEST4: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateCharismaBonusText(8);

            Assert.AreEqual(-1, cc2.chaBonus_ReactionAdjustment, "TEST5: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(3, cc2.chaBonus_NoOfRetainers, "TEST6: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(6, cc2.chaBonus_RetainerMorale, "TEST7: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("-1 to adjustment to reactions, maximum numbers of retainers 3" +
                    Environment.NewLine + "morale of retainers 6", retCc2, "TEST8: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateCharismaBonusText_WhereCharismaBonusAllows4Retainer()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateCharismaBonusText(9);

            Assert.AreEqual(0, cc1.chaBonus_ReactionAdjustment, "TEST1: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(4, cc1.chaBonus_NoOfRetainers, "TEST2: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(7, cc1.chaBonus_RetainerMorale, "TEST3: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("0 to adjustment to reactions, maximum numbers of retainers 4" +
                    Environment.NewLine + "morale of retainers 7", retCc1, "TEST4: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateCharismaBonusText(12);

            Assert.AreEqual(0, cc2.chaBonus_ReactionAdjustment, "TEST5: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(4, cc2.chaBonus_NoOfRetainers, "TEST6: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(7, cc2.chaBonus_RetainerMorale, "TEST7: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("0 to adjustment to reactions, maximum numbers of retainers 4" +
                    Environment.NewLine + "morale of retainers 7", retCc2, "TEST8: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateCharismaBonusText_WhereCharismaBonusAllows5Retainer()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateCharismaBonusText(13);

            Assert.AreEqual(1, cc1.chaBonus_ReactionAdjustment, "TEST1: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(5, cc1.chaBonus_NoOfRetainers, "TEST2: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(8, cc1.chaBonus_RetainerMorale, "TEST3: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("+1 to adjustment to reactions, maximum numbers of retainers 5" +
                    Environment.NewLine + "morale of retainers 8", retCc1, "TEST4: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateCharismaBonusText(15);

            Assert.AreEqual(1, cc2.chaBonus_ReactionAdjustment, "TEST5: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(5, cc2.chaBonus_NoOfRetainers, "TEST6: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(8, cc2.chaBonus_RetainerMorale, "TEST7: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("+1 to adjustment to reactions, maximum numbers of retainers 5" +
                    Environment.NewLine + "morale of retainers 8", retCc2, "TEST8: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateCharismaBonusText_WhereCharismaBonusAllows6Retainer()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateCharismaBonusText(16);

            Assert.AreEqual(1, cc1.chaBonus_ReactionAdjustment, "TEST1: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(6, cc1.chaBonus_NoOfRetainers, "TEST2: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(9, cc1.chaBonus_RetainerMorale, "TEST3: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("+1 to adjustment to reactions, maximum numbers of retainers 6" +
                    Environment.NewLine + "morale of retainers 9", retCc1, "TEST4: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();

            var retCc2 = cc2.UpdateCharismaBonusText(17);

            Assert.AreEqual(1, cc2.chaBonus_ReactionAdjustment, "TEST5: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(6, cc2.chaBonus_NoOfRetainers, "TEST6: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(9, cc2.chaBonus_RetainerMorale, "TEST7: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("+1 to adjustment to reactions, maximum numbers of retainers 6" +
                    Environment.NewLine + "morale of retainers 9", retCc2, "TEST8: The returned string is not as expected");
        }

        [TestMethod]
        public void TestUpdateCharismaBonusText_WhereCharismaBonusAllows7Retainer()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var retCc1 = cc1.UpdateCharismaBonusText(18);

            Assert.AreEqual(2, cc1.chaBonus_ReactionAdjustment, "TEST1: The Charisma bonus to Reaction adjustment is not as expected");
            Assert.AreEqual(7, cc1.chaBonus_NoOfRetainers, "TEST2: The Charisma bonus to Number of Retainers is not as expected");
            Assert.AreEqual(10, cc1.chaBonus_RetainerMorale, "TEST3: The Charisma bonus to Retainer Morale is not as expected");
            Assert.AreEqual("+2 to adjustment to reactions, maximum numbers of retainers 7" +
                    Environment.NewLine + "morale of retainers 10", retCc1, "TEST4: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetClassDescription_WhereInputIsFighter()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var ret = cc1.GetClassDescription(Dungeons_and_Dragons.ClassType.Fighter);
            
            Assert.AreEqual("Fighters are characters trained for battle. Their main purpose is to fight monsters and protect weaker members of the party.", ret, 
                "TEST1: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetClassDescription_WhereInputIsThief()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var ret = cc1.GetClassDescription(Dungeons_and_Dragons.ClassType.Thief);

            Assert.AreEqual("Thieves are characters trained in the arts of stealing and sneaking.  They are the only class that can pick locks and disarm traps without using magic.", ret, 
                "TEST1: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetClassDescription_WhereInputIsMagicUser()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var ret = cc1.GetClassDescription(Dungeons_and_Dragons.ClassType.MagicUser);

            Assert.AreEqual("Magic-Users are characters who through training and practice have learned to cast spells.", ret,
                "TEST1: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetClassDescription_WhereInputIsCleric()
        {
            CharacterCreator cc1 = new CharacterCreator();

            var ret = cc1.GetClassDescription(Dungeons_and_Dragons.ClassType.Cleric);

            Assert.AreEqual("Clerics are characters who have dedicated themselves to the service of god or goddess.  They are trained in fighting and given the ability to use magic by their gods.",
                ret, "TEST1: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetPrimeRequisiteBonusText_WhereBonusIsMinus20()
        {
            CharacterCreator cc1 = new CharacterCreator();
            cc1.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Strength, 3);

            var retCc1 = cc1.GetPrimeRequisiteBonusText(Dungeons_and_Dragons.Attribute.Strength);

            Assert.AreEqual("-20% from earned experience points", retCc1, "TEST1: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();
            cc2.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Dexterity, 5);

            var retCc2 = cc2.GetPrimeRequisiteBonusText(Dungeons_and_Dragons.Attribute.Dexterity);

            Assert.AreEqual("-20% from earned experience points", retCc2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetPrimeRequisiteBonusText_WhereBonusIsMinus10()
        {
            CharacterCreator cc1 = new CharacterCreator();
            cc1.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Intelligence, 6);

            var retCc1 = cc1.GetPrimeRequisiteBonusText(Dungeons_and_Dragons.Attribute.Intelligence);

            Assert.AreEqual("-10% from earned experience points", retCc1, "TEST1: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();
            cc2.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Wisdom, 8);

            var retCc2 = cc2.GetPrimeRequisiteBonusText(Dungeons_and_Dragons.Attribute.Wisdom);

            Assert.AreEqual("-10% from earned experience points", retCc2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetPrimeRequisiteBonusText_WhereBonusIsZero()
        {
            CharacterCreator cc1 = new CharacterCreator();
            cc1.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Intelligence, 9);

            var retCc1 = cc1.GetPrimeRequisiteBonusText(Dungeons_and_Dragons.Attribute.Intelligence);

            Assert.AreEqual("No adjustment to experience points", retCc1, "TEST1: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();
            cc2.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Wisdom, 12);

            var retCc2 = cc2.GetPrimeRequisiteBonusText(Dungeons_and_Dragons.Attribute.Wisdom);

            Assert.AreEqual("No adjustment to experience points", retCc2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetPrimeRequisiteBonusText_WhereBonusIsPlus5()
        {
            CharacterCreator cc1 = new CharacterCreator();
            cc1.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Strength, 13);

            var retCc1 = cc1.GetPrimeRequisiteBonusText(Dungeons_and_Dragons.Attribute.Strength);

            Assert.AreEqual("+5% from earned experience points", retCc1, "TEST1: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();
            cc2.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Dexterity, 15);

            var retCc2 = cc2.GetPrimeRequisiteBonusText(Dungeons_and_Dragons.Attribute.Dexterity);

            Assert.AreEqual("+5% from earned experience points", retCc2, "TEST2: The returned string is not as expected");
        }

        [TestMethod]
        public void TestGetPrimeRequisiteBonusText_WhereBonusIsPlus10()
        {
            CharacterCreator cc1 = new CharacterCreator();
            cc1.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Intelligence, 16);

            var retCc1 = cc1.GetPrimeRequisiteBonusText(Dungeons_and_Dragons.Attribute.Intelligence);

            Assert.AreEqual("+10% from earned experience points", retCc1, "TEST1: The returned string is not as expected");


            CharacterCreator cc2 = new CharacterCreator();
            cc2.originalAttributes.Add(Dungeons_and_Dragons.Attribute.Wisdom, 18);

            var retCc2 = cc2.GetPrimeRequisiteBonusText(Dungeons_and_Dragons.Attribute.Wisdom);

            Assert.AreEqual("+10% from earned experience points", retCc2, "TEST2: The returned string is not as expected");
        }
    }
}
