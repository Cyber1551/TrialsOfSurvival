﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player Progression", menuName = "Stats/Player Progression", order = 0)]
public class PlayerProgression : ScriptableObject
{
    [SerializeField] List<WeaponProgressionType> weaponProgressionTypes; 

    public int GetStat(Stat stat, BaseSkill weapon)
    {
        ProgressionStat weaponStat = weaponProgressionTypes.Find(w => w.weaponType == weapon.weaponType).stats.Find(s => s.stat == stat);
        return weaponStat.Levels[weapon.Level - 1];
    }
    [System.Serializable]
    class WeaponProgressionType
    {
        public WeaponType weaponType;
        public List<ProgressionStat> stats; 
    }
    [System.Serializable] 
    class ProgressionStat
    {
        public Stat stat;
        public int[] Levels;
    }
}
