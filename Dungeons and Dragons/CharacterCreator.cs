using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons
{
    public enum Attribute
    {
        Strength,
        Dexterity,
        Intelligence,
        Wisdom,
        Constitution,
        Charisma
    }

    public enum ClassType
    {
        Fighter = 1,
        Thief = 2,
        MagicUser = 3,
        Cleric = 4
    }

    public enum Race
    {
        Dwarf = 1,
        Elf = 2,
        Halfling = 3,
        Human = 4
    }


    public class CharacterCreator
    {
        private Dictionary<Attribute, int> OriginalAttributes;

        public Dictionary<Attribute, int> originalAttributes
        {
            get
            {
                return OriginalAttributes;
            }
        }

        private Dictionary<Attribute, int> AmendedAttributes;

        public Dictionary<Attribute, int> amendedAttributes
        {
            get
            {
                return AmendedAttributes;
            }
        }

        private int UnassignedPoints = 0;

        public int unassignedPoints
        {
            get
            {
                return UnassignedPoints;
            }
        }

        private ClassType ClassType;

        public ClassType classType
        {
            get
            {
                return ClassType;
            }
        }

        private Attribute PrimeRequisite;
        
        public Attribute primeRequisite
        {
            get
            {
                return PrimeRequisite;
            }
        }

        private Race CharacterRace;

        public Race characterRace
        {
            get
            {
                return CharacterRace;
            }
        }

        private string CharcterName;

        public string characterName
        {
            get
            {
                return CharcterName;
            }
        }

        private int StrBonus_ToHit_Damage_ToOpenDoor;

        public int strBonus_ToHit_Damage_ToOpenDoor
        {
            get
            {
                return StrBonus_ToHit_Damage_ToOpenDoor;
            }
        }

        private int DexBonus_ToHitMissiles;

        public int dexBonus_ToHitMissiles
        {
            get
            {
                return DexBonus_ToHitMissiles;
            }
        }

        private int DexBonus_AcAdjustment;
        
        public int dexBonus_AcAdjustment
        {
            get
            {
                return DexBonus_AcAdjustment;
            }
        }

        private int DexBonus_InitiativeAdjustment;

        public int dexBonus_InitiativeAdjustment
        {
            get
            {
                return DexBonus_InitiativeAdjustment;
            }
        }

        private int WisBonus_MagicBasedSavingThrowAdjustment;

        public int wisBonus_MagicBasedSavingThrowAdjustment
        {
            get
            {
                return WisBonus_MagicBasedSavingThrowAdjustment;
            }
        }

        private int ConBonus_HitPointAdjustment;

        public int conBonus_HitPointAdjustment
        {
            get
            {
                return ConBonus_HitPointAdjustment;
            }
        }

        private int ChaBonus_ReactionAdjustment;

        public int chaBonus_ReactionAdjustment
        {
            get
            {
                return ChaBonus_ReactionAdjustment;
            }
        }

        private int ChaBonus_NoOfRetainers;

        public int chaBonus_NoOfRetainers
        {
            get
            {
                return ChaBonus_NoOfRetainers;
            }
        }

        private int ChaBonus_RetainerMorale;

        public int chaBonus_RetainerMorale
        {
            get
            {
                return ChaBonus_RetainerMorale;
            }
        }

        private int HitPoints;
        
        public int hitPoints
        {
            get
            {
                return HitPoints;
            }
        }


        public CharacterCreator()
        {
            OriginalAttributes = new Dictionary<Attribute, int>();
            AmendedAttributes = new Dictionary<Attribute, int>();
            CharcterName = "";
        }

        public void SetClass(ClassType classType)
        {
            ClassType = classType;
            int hitPointBonus = AttributeBonuses.GetConstitution_HitPointBonus(OriginalAttributes[Attribute.Constitution]);

            switch (classType)
            {
                case ClassType.Fighter:
                    {
                        PrimeRequisite = Attribute.Strength;
                        HitPoints = Character.GetAdditionalHitPointsForNewLevel(DiceRoll.Roll(1, DiceType.D8), hitPointBonus);
                        break;
                    }
                case ClassType.Thief:
                    {
                        PrimeRequisite = Attribute.Dexterity;
                        HitPoints = Character.GetAdditionalHitPointsForNewLevel(DiceRoll.Roll(1, DiceType.D4), hitPointBonus);
                        break;
                    }
                case ClassType.MagicUser:
                    {
                        PrimeRequisite = Attribute.Intelligence;
                        HitPoints = Character.GetAdditionalHitPointsForNewLevel(DiceRoll.Roll(1, DiceType.D4), hitPointBonus);
                        break;
                    }
                case ClassType.Cleric:
                    {
                        PrimeRequisite = Attribute.Wisdom;
                        HitPoints = Character.GetAdditionalHitPointsForNewLevel(DiceRoll.Roll(1, DiceType.D6), hitPointBonus);
                        break;
                    }
            }
        }

        public void setRace(Race race)
        {
            CharacterRace = race;
        }

        public void setCharacterName(string name)
        {
            CharcterName = name;
        }

        public Dictionary<Attribute, int> RollAttibutes()
        {
            OriginalAttributes.Add(Attribute.Strength, DiceRoll.Roll(3, DiceType.D6));
            OriginalAttributes.Add(Attribute.Dexterity, DiceRoll.Roll(3, DiceType.D6));
            OriginalAttributes.Add(Attribute.Intelligence, DiceRoll.Roll(3, DiceType.D6));
            OriginalAttributes.Add(Attribute.Wisdom, DiceRoll.Roll(3, DiceType.D6));
            OriginalAttributes.Add(Attribute.Constitution, DiceRoll.Roll(3, DiceType.D6));
            OriginalAttributes.Add(Attribute.Charisma, DiceRoll.Roll(3, DiceType.D6));

            SetAmendedAttributesToOriginal();

            return OriginalAttributes;
        }

        public void SetAmendedAttributesToOriginal()
        {
            AmendedAttributes = OriginalAttributes.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        public void SetOriginalAttributesToAmended()
        {
            OriginalAttributes = AmendedAttributes.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        private List<Attribute> GetBestAttribute(Dictionary<Attribute, int> dict)
        {
            int BestValue = 0;
            List<Attribute> BestAttribute = new List<Attribute>();

            foreach (KeyValuePair<Attribute, int> entry in dict)
            {
                if (entry.Key != Attribute.Constitution || entry.Key != Attribute.Charisma)
                {
                    if (entry.Value > BestValue)
                    {
                        BestAttribute.Clear();
                        BestValue = entry.Value;
                        BestAttribute.Add(entry.Key);
                    }
                    else if (entry.Value == BestValue)
                    {
                        BestAttribute.Add(entry.Key);
                    }
                }
            }

            return BestAttribute;
        }

        public string GetSuggestedClass()
        {
            Dictionary<Attribute, int> tempDict = new Dictionary<Attribute, int>();
            List<string> suggestedClasses = new List<string>();
            string output = "";

            foreach (KeyValuePair<Attribute, int> entry in OriginalAttributes)
            {
                if (entry.Key != Attribute.Constitution && entry.Key != Attribute.Charisma)
                {
                    tempDict.Add(entry.Key, entry.Value);
                }
            }

            List<Attribute> BestAttributes = GetBestAttribute(tempDict);

            foreach (Attribute att in BestAttributes)
            {
                switch (att)
                {
                    case Attribute.Strength:
                        {
                            suggestedClasses.Add("Fighter");
                            break;
                        }
                    case Attribute.Intelligence:
                        {
                            suggestedClasses.Add("Magic-User");
                            break;
                        }
                    case Attribute.Wisdom:
                        {
                            suggestedClasses.Add("Cleric");
                            break;
                        }
                    case Attribute.Dexterity:
                        {
                            suggestedClasses.Add("Thief");
                            break;
                        }
                }
            }

            if (BestAttributes.Count == 1)
            {
                output = suggestedClasses[0];
            }
            else
            {
                for (int i = 0; i < suggestedClasses.Count; i++)
                {
                    if (i == suggestedClasses.Count - 1)
                    {
                        output += " or ";

                    }
                    else if (i != 0)
                    {
                        output += ", ";
                    }

                    output += suggestedClasses[i];
                }
            }

            return output;
        }

        public string IncreaseAttribute(Attribute attribute)
        {
            string output = "";

            if (UnassignedPoints >= 2)
            {
                if (amendedAttributes[attribute] == 18)
                {
                    output = "It is not possible to increase an attribute above 18";
                }
                else
                {
                    amendedAttributes[attribute] = amendedAttributes[attribute] + 1;
                    AlterUnassignedPoints(-2);
                }
            }
            else
            {
                output = "You need at least 2 unassigned points to raise an attribute by 1 point";
            }

            return output;
        }

        public string DecreaseAttribute(Attribute attribute)
        {
            string output = "";

            if (amendedAttributes[attribute] == 3)
            {
                output = "It is not possible to decrease an attribute below 3";
            }
            else
            {
                amendedAttributes[attribute] = amendedAttributes[attribute] - 1;
                AlterUnassignedPoints(1);
            }

            return output;
        }

        public void AlterUnassignedPoints(int change)
        {
            UnassignedPoints = UnassignedPoints + change;
        }

        private void SetStrenghtBonus(int value)
        {
            StrBonus_ToHit_Damage_ToOpenDoor = AttributeBonuses.GetStrenghtBonus(value);
        }

        public string UpdateStrengthBonusText(int value)
        {
            SetStrenghtBonus(value);

            if (StrBonus_ToHit_Damage_ToOpenDoor != 0)
            {
                if(StrBonus_ToHit_Damage_ToOpenDoor > 0)
                {
                    return "+" + StrBonus_ToHit_Damage_ToOpenDoor + " to hit, damage and opening doors";
                }
                else
                {
                    return StrBonus_ToHit_Damage_ToOpenDoor + " to hit, damage and opening doors";
                }
            }
            else
            {
                return "No adjustments due to Strength";
            }
        }

        private void SetDexterityBonus(int value)
        {
            DexBonus_ToHitMissiles = AttributeBonuses.GetDexterity_ToHitMissilesBonus(value);
            DexBonus_AcAdjustment = AttributeBonuses.GetDexterity_AcAdjustmentBonus(value);
            DexBonus_InitiativeAdjustment = AttributeBonuses.GetDexterity_InitiativeBonus(value);
        }


        public string UpdateDexterityBonusText(int value)
        {
            string bonusText = "";
            SetDexterityBonus(value);

            if(DexBonus_ToHitMissiles == 0)
            {
                bonusText = "No adjustments due to Dexterity";
            }
            else if (DexBonus_ToHitMissiles > 0)
            {
                bonusText = "+" + DexBonus_ToHitMissiles + " missile 'to hit' rolls, " + DexBonus_AcAdjustment + " Armour Class Adjustment, +" + DexBonus_InitiativeAdjustment + " Initiative Adjustment";
            }
            else 
            {
                bonusText = DexBonus_ToHitMissiles + " missile 'to hit' rolls, +" + DexBonus_AcAdjustment + " Armour Class Adjustment, " + DexBonus_InitiativeAdjustment + " Initiative Adjustment";
            }

            return bonusText;
        }


        public string UpdateIntelligenceBonusText(int value)
        {
            string bonusText = "";

            if (value == 3)
            {
                bonusText = "Has trouble with speaking, cannot read or write";
            }
            else if (value >= 4 && value < 6)
            {
                bonusText = "Cannot read or write Common";
            }
            else if (value >= 6 && value < 9)
            {
                bonusText = "Can write simple Common words";
            }
            else if (value >= 9 && value < 13)
            {
                bonusText = "Reads and writes native languages, usually 2";
            }
            else if (value >= 13 && value < 16)
            {
                bonusText = "Reads and writes native languages, usually 2, +1 extra language";
            }
            else if (value >= 16 && value < 18)
            {
                bonusText = "Reads and writes native languages, usually 2, +2 extra language";
            }
            else
            {
                bonusText = "Reads and writes native languages, usually 2, +3 extra language";
            }

            return bonusText;
        }

        private void SetWisdomBonus(int value)
        {
            WisBonus_MagicBasedSavingThrowAdjustment = AttributeBonuses.GetWisdomBonus(value);
        }

        public string UpdateWisdomBonusText(int value)
        {
            string bonusText = "";
            SetWisdomBonus(value);

            if (WisBonus_MagicBasedSavingThrowAdjustment == 0)
            {
                bonusText = "No adjustments due to Wisdom";
            }
            else if (WisBonus_MagicBasedSavingThrowAdjustment > 0)
            {
                bonusText = "+" + WisBonus_MagicBasedSavingThrowAdjustment + " on magic based saving throws";
            }
            else
            {
                bonusText = WisBonus_MagicBasedSavingThrowAdjustment + " on magic based saving throws";
            }
            
            return bonusText;
        }

        private void SetConstitutionBonus(int value)
        {
            ConBonus_HitPointAdjustment = AttributeBonuses.GetConstitution_HitPointBonus(value);
        }

        public string UpdateConstitutionBonusText(int value)
        {
            string bonusText = "";
            SetConstitutionBonus(value);

            if (ConBonus_HitPointAdjustment == 0)
            {
                bonusText = "No adjustments due to Constitution";
            }
            else if (ConBonus_HitPointAdjustment > 0)
            {
                bonusText = "+" + ConBonus_HitPointAdjustment + " points per hit dice";
            }
            else
            {
                bonusText = ConBonus_HitPointAdjustment + " points per hit dice";
            }

            return bonusText;
        }

        private void SetCharimsaBonus(int value)
        {
            ChaBonus_ReactionAdjustment = AttributeBonuses.GetCharimsaBonus_ReactionAdjustment(value);
            ChaBonus_NoOfRetainers = AttributeBonuses.GetCharimsaBonus_NoOfRetainers(value);
            ChaBonus_RetainerMorale = AttributeBonuses.GetCharimsaBonus_RetainersMorale(value);
        }

        public string UpdateCharismaBonusText(int value)
        {
            string bonusText = "";
            SetCharimsaBonus(value);

            if (ChaBonus_ReactionAdjustment > 0)
            {
                bonusText = "+" + chaBonus_ReactionAdjustment + " to adjustment to reactions, maximum numbers of retainers " + chaBonus_NoOfRetainers 
                    + Environment.NewLine + "morale of retainers " + chaBonus_RetainerMorale;
            }
            else
            {
                bonusText = chaBonus_ReactionAdjustment + " to adjustment to reactions, maximum numbers of retainers " + chaBonus_NoOfRetainers
                   + Environment.NewLine + "morale of retainers " + chaBonus_RetainerMorale;
            }
            return bonusText;
        }

        public string GetClassDescription(ClassType classType)
        {
            string output = "";

            switch (classType)
            {
                case ClassType.Fighter:
                    {
                        output = "Fighters are characters trained for battle. Their main purpose is to fight monsters and protect weaker members of the party.";
                        break;
                    }
                case ClassType.Thief:
                    {
                        output = "Thieves are characters trained in the arts of stealing and sneaking.  They are the only class that can pick locks and disarm traps without using magic.";
                        break;
                    }
                case ClassType.MagicUser:
                    {
                        output = "Magic-Users are characters who through training and practice have learned to cast spells.";
                        break;
                    }
                case ClassType.Cleric:
                    {
                        output = "Clerics are characters who have dedicated themselves to the service of god or goddess.  They are trained in fighting and given the ability to use magic by their gods.";
                        break;
                    }
            }
            return output;
        }

        public string GetPrimeRequisiteBonusText(Attribute attribute)
        {
            int attributeScore = OriginalAttributes[attribute];
            int bonusPercent = AttributeBonuses.GetPrimeRequisiteXPBonus(attributeScore);
            string bonusText = "";

            if (bonusPercent == 0)
            {
                bonusText = "No adjustment to experience points";
            }
            else if (bonusPercent > 0)
            {
                bonusText = "+" + bonusPercent + "% from earned experience points";
            }
            else
            {
                bonusText = bonusPercent + "% from earned experience points";
            }
            return bonusText;
        }

        //useful stuff https://www.youtube.com/watch?v=_PCBTiXL884

        public void SaveCharacter()
        {
            int xp = 0;

            switch (ClassType)
            {
                case ClassType.Fighter:
                    {
                        Fighter newCharacter = new Fighter(characterName, characterRace, originalAttributes, HitPoints, xp);
                        newCharacter.Save();
                        break;
                    }
                case ClassType.Thief:
                    {
                        Thief newCharacter = new Thief(characterName, characterRace, originalAttributes, HitPoints, xp);
                        newCharacter.Save();
                        break;
                    }
                case ClassType.Cleric:
                    {
                        Cleric newCharacter = new Cleric(characterName, characterRace, originalAttributes, HitPoints, xp);
                        newCharacter.Save();
                        break;
                    }
                case ClassType.MagicUser:
                    {
                        MagicUser newCharacter = new MagicUser(characterName, characterRace, originalAttributes, HitPoints, xp);
                        newCharacter.Save();
                        break;
                    }
            }

        }
    }
}
