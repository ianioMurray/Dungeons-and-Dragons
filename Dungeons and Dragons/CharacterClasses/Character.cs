using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeons_and_Dragons.InteractItems;

namespace Dungeons_and_Dragons
{
    public enum Hand
    {
        Right = 1,
        Left = 2
    };

    public enum EquipsTo
    {
        Body = 1,
        Hand = 2,
        Head = 3
    };

    public abstract class Character : Individual
    {
        private string Name;

        public string name
        {
            get
            {
                return Name;
            }
        }

        private Race CharactersRace;

        public Race characterRace
        {
            get
            {
                return CharactersRace;
            }
        }

        private Dictionary<Attribute, int> Attributes;

        public Dictionary<Attribute, int> attributes
        {
            get
            {
                return Attributes;
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
        
        protected int CurrentLevel;

        public int currentLevel
        {
            get
            {
                return CurrentLevel;
            }
        }

        private int ExperiencePoints;

        public int experiencePoints
        {
            get
            {
                return ExperiencePoints;
            }
        }

        private List<EquipmentItems> Inventory;
    
        public List<EquipmentItems> inventory
        {
            get
            {
                return Inventory;
            }
        }

        private EquipmentItems EquippedInRightHand;

        public EquipmentItems equippedInRightHand
        {
            get
            {
                return EquippedInRightHand;
            }
        }

        private EquipmentItems EquippedInLeftHand;

        public EquipmentItems equippedInLeftHand
        {
            get
            {
                return EquippedInLeftHand;
            }
        }

        private EquipmentItems EquippedToBody;

        public EquipmentItems equippedToBody
        {
            get
            {
                return EquippedToBody;
            }
        }

        private int ArmourClass;

        public int armourClass
        {
            get
            {
                return ArmourClass;
            }
        }

        private int CharacterId;

        public int characterId
        {
            get
            {
                return CharacterId;
            }
        }


        private double ExperiencePointMultiplier;
        private int StrBonus_ToHitMeleeBonus_DamageBonus_ToOpenDoorBonus;
        private int DexBonus_ToHitMissilesBonus;
        private int DexBonus_AcAdjustment;
        private int DexBonus_InitiativeAdjustment;
        private int WisBonus_MagicBasedSavingThrowAdjustment;
        protected int ConBonus_HitPointAdjustment;
        private int ChaBonus_ReactionAdjustment;
        private int ChaBonus_NoOfRetainers;
        private int ChaBonus_RetainerMorale;

        protected Character(string name, Race characterRace, Dictionary<Attribute, int> attributes, int hitPoints, int experiencePoints)
        {
            Name = name;
            CharactersRace = characterRace;
            Attributes = attributes;
            this.hitPoints = hitPoints;
            ExperiencePoints = experiencePoints;
            Inventory = new List<EquipmentItems>();
            EquippedInRightHand = null;
            EquippedInLeftHand = null;
            EquippedToBody = null;
            CharacterId = 0;

            StrBonus_ToHitMeleeBonus_DamageBonus_ToOpenDoorBonus = AttributeBonuses.GetStrenghtBonus(Attributes[Attribute.Strength]);
            DexBonus_ToHitMissilesBonus = AttributeBonuses.GetDexterity_ToHitMissilesBonus(Attributes[Attribute.Dexterity]);
            DexBonus_AcAdjustment = AttributeBonuses.GetDexterity_AcAdjustmentBonus(Attributes[Attribute.Dexterity]);
            DexBonus_InitiativeAdjustment = AttributeBonuses.GetDexterity_AcAdjustmentBonus(Attributes[Attribute.Dexterity]);
            WisBonus_MagicBasedSavingThrowAdjustment = AttributeBonuses.GetWisdomBonus(Attributes[Attribute.Wisdom]);
            ConBonus_HitPointAdjustment = AttributeBonuses.GetConstitution_HitPointBonus(Attributes[Attribute.Constitution]);
            ChaBonus_ReactionAdjustment = AttributeBonuses.GetCharimsaBonus_ReactionAdjustment(Attributes[Attribute.Charisma]);
            ChaBonus_NoOfRetainers = AttributeBonuses.GetCharimsaBonus_NoOfRetainers(Attributes[Attribute.Charisma]);
            ChaBonus_RetainerMorale = AttributeBonuses.GetCharimsaBonus_RetainersMorale(Attributes[Attribute.Charisma]);

            SetArmourClass();
        }

        public void SetCharacterId(int charId)
        {
            CharacterId = charId;
        }

        protected void SetPrimeRequisite(Attribute primeRequisite)
        {
            PrimeRequisite = primeRequisite;
        }

        public virtual void IncreaseExperiencePoints(int xpPoints)
        {
            double xpIncreaseWithMultiplier = Math.Round(xpPoints * ExperiencePointMultiplier, 0);
            ExperiencePoints += (int)xpIncreaseWithMultiplier;
        }

        public void SetExperiencePointMultiplier(int value)
        {
            double val = (value / 100.0);
            ExperiencePointMultiplier = 1 + val;
        }

        protected int GetLevel(List<int> levelThreshold)
        {
            int level = 1;

            for (int count = 1; count <= levelThreshold.Count; count++)
            {
                if (levelThreshold[count - 1] <= ExperiencePoints)
                {
                    level = count;
                }
            }

            return level;
        }

        public static int GetAdditionalHitPointsForNewLevel(int hitPointRoll, int hitPointBonus)
        {
            int points = hitPointRoll + hitPointBonus;

            if (points <= 0)
            {
                points = 1;
            }
            return points;
        }

        public void AddToCharactersInventory(EquipmentItems item)
        {
            Inventory.Add(item);
        }

        public abstract bool ItemUseable(EquipmentItems item);

        public bool EquipToHand(EquipmentItems item, Hand hand)
        {
            if(ItemUseable(item))
            {
                if(item is Armour)
                {
                    Armour armour = (Armour)item;

                    if(armour.equipsTo != EquipsTo.Hand)
                    {
                        return false;
                    }
                }

                if (item is Weapon)
                {
                    Weapon weapon = (Weapon)item;

                    Hand handOne;
                    Hand handTwo;

                    if(hand == Hand.Left)
                    {
                        handOne = Hand.Left;
                        handTwo = Hand.Right;
                    }
                    else
                    {
                        handOne = Hand.Right;
                        handTwo = Hand.Left;
                    }

                    if (weapon.twoHanded)
                    {
                        UnequipItemFromHand(handTwo);
                        SetEquippedItemToHand(item, handTwo);
                    }

                    UnequipItemFromHand(handOne);
                    SetEquippedItemToHand(item, handOne);
                    SetArmourClass();
                }
                else
                {
                    UnequipItemFromHand(hand);
                    SetEquippedItemToHand(item, hand);
                    SetArmourClass();
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool EquipToBody(EquipmentItems item)
        {
            if (ItemUseable(item))
            {
                if (item is Armour)
                {
                    Armour armour = (Armour)item;

                    if (armour.equipsTo != EquipsTo.Body)
                    {
                        return false;
                    }
                    
                    //unequip whatever was equipped to the body and move it to the inventory
                    if(EquippedToBody != null)
                    {
                        Inventory.Add(EquippedToBody);
                        EquippedToBody = null;
                    }

                    EquippedToBody = item;
                    SetArmourClass();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public void UnequipItemFromHand(Hand hand)
        {
            if(hand == Hand.Right)
            {               
                if (EquippedInRightHand != null)
                {
                    Inventory.Add(EquippedInRightHand);

                    if (EquippedInRightHand is Weapon)
                    {
                        Weapon weaponInHand = (Weapon)EquippedInRightHand;
                        if(weaponInHand.twoHanded)
                        {
                            EquippedInLeftHand = null;
                        }
                    }
                    EquippedInRightHand = null;
                }
            }
            else
            {
                if (EquippedInLeftHand != null)
                {
                    Inventory.Add(EquippedInLeftHand);

                    if (EquippedInLeftHand is Weapon)
                    {
                        Weapon weaponInHand = (Weapon)EquippedInLeftHand;
                        if (weaponInHand.twoHanded)
                        {
                            EquippedInRightHand = null;
                        }
                    }
                    EquippedInLeftHand = null;
                }
            }
        }

        private void SetEquippedItemToHand(EquipmentItems item, Hand hand)
        {
            if(hand == Hand.Right)
            {
                EquippedInRightHand = item;
            }
            else
            {
                EquippedInLeftHand = item;
            }
        }

        private void SetArmourClass()
        {
            int armourValue = 9;

            if(equippedToBody != null)
            {
                Armour armour = (Armour)equippedToBody;
                armourValue += armour.armourClass; 
            }

            if(equippedInLeftHand is Armour)
            {
                Armour armour = (Armour)equippedInLeftHand;
                armourValue += armour.armourClass;
            }

            if (equippedInRightHand is Armour)
            {
                Armour armour = (Armour)equippedInRightHand;
                armourValue += armour.armourClass;
            }
            armourValue += DexBonus_AcAdjustment;

            if(armourValue > 9)
            {
                armourValue = 9;
            }

            ArmourClass = armourValue;
        }
    }
}
