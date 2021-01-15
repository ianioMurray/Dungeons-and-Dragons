using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeons_and_Dragons.InteractItems;

namespace Dungeons_and_Dragons
{
    public enum ThiefAbilities
    {
        PickLock = 1,
        FindRemoveTraps = 2,
        PickPocket = 3,
        MoveSilently = 4,
        ClimbSheerSurfaces = 5,
        HideInShadows = 6,
        HearNoise
    };

    public class Thief : Character
    {
        private List<int> levelThreshold = new List<int>
        {
            0,
            1200,
            2400,
        };

        private Dictionary<ThiefAbilities, int> FirstLevelThiefAbilityScores = new Dictionary<ThiefAbilities, int>
            {
                { ThiefAbilities.PickLock, 15 },
                { ThiefAbilities.FindRemoveTraps, 10 },
                { ThiefAbilities.PickPocket, 20 },
                { ThiefAbilities.MoveSilently, 20 },
                { ThiefAbilities.ClimbSheerSurfaces, 87 },
                { ThiefAbilities.HideInShadows, 10 },
                { ThiefAbilities.HearNoise, 33 }
            };

        private Dictionary<ThiefAbilities, int> SecondLevelThiefAbilityScores = new Dictionary<ThiefAbilities, int>
            {
                { ThiefAbilities.PickLock, 20 },
                { ThiefAbilities.FindRemoveTraps, 15 },
                { ThiefAbilities.PickPocket, 25 },
                { ThiefAbilities.MoveSilently, 25 },
                { ThiefAbilities.ClimbSheerSurfaces, 88 },
                { ThiefAbilities.HideInShadows, 15 },
                { ThiefAbilities.HearNoise, 33 }
            };

        private Dictionary<ThiefAbilities, int> ThirdLevelThiefAbilityScores = new Dictionary<ThiefAbilities, int>
            {
                { ThiefAbilities.PickLock, 25 },
                { ThiefAbilities.FindRemoveTraps, 20 },
                { ThiefAbilities.PickPocket, 30 },
                { ThiefAbilities.MoveSilently, 30 },
                { ThiefAbilities.ClimbSheerSurfaces, 89 },
                { ThiefAbilities.HideInShadows, 20 },
                { ThiefAbilities.HearNoise, 50 }
            };

        private Dictionary<ThiefAbilities, int> ThievingAbilities;

        public Dictionary<ThiefAbilities, int> thievingAbilities
        {
            get
            {
                return ThievingAbilities;
            }
        }


        public Thief(string name, Race characterRace, Dictionary<Attribute, int> attributes, int hitPoints, int xp) 
            : base(name, characterRace, attributes, hitPoints, xp)
        {
            SetPrimeRequisite(Attribute.Dexterity);
            SetExperiencePointMultiplier(AttributeBonuses.GetPrimeRequisiteXPBonus(attributes[Attribute.Dexterity]));
            CurrentLevel = GetThiefLevel();
            SetThievesAbilities(CurrentLevel);
        }

        public void Save()
        {
            Repository rep = new Repository();
            rep.SaveCharacter(this, ClassType.Thief);
        }

        public int GetThiefLevel()
        {
            return GetLevel(levelThreshold);
        }

        public override void IncreaseExperiencePoints(int xpPoints)
        {
            base.IncreaseExperiencePoints(xpPoints);
            int newLevel = GetThiefLevel();

            if(newLevel > CurrentLevel)
            {
                LevelUpCharacter(newLevel);
            }

            CurrentLevel = newLevel;
        }

        public void LevelUpCharacter(int newLevel)
        {
            hitPoints += Character.GetAdditionalHitPointsForNewLevel(DiceRoll.Roll(1, DiceType.D4),
                ConBonus_HitPointAdjustment);
            SetThievesAbilities(newLevel);
        }

        public void SetThievesAbilities(int newLevel)
        {
            switch (newLevel)
            {
                case 1:
                    {
                        ThievingAbilities = FirstLevelThiefAbilityScores;
                        break;
                    }
                case 2:
                    {
                        ThievingAbilities = SecondLevelThiefAbilityScores;
                        break;
                    }
                case 3:
                    {
                        ThievingAbilities = ThirdLevelThiefAbilityScores;
                        break;
                    }
            }

        }

        public override bool ItemUseable(EquipmentItems item)
        {
            if (item is Armour)
            {
                Armour armour = (Armour)item;

                if(!armour.useableByThieves)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
