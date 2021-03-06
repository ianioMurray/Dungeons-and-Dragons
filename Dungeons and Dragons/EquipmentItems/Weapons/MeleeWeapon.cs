﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public abstract class MeleeWeapon : Weapon
    {
        public MeleeWeapon(string name, DiceType damage, int cost, bool twoHanded, bool bladed, bool usableByMagicUser, WeaponType type) 
            : base (name, damage, cost, twoHanded, bladed, usableByMagicUser, type)
        {
        }
    }
}
