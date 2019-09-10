using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player Progression", menuName = "Stats/Player Progression", order = 0)]
public class PlayerProgression : ScriptableObject
{
    [SerializeField] List<WeaponProgressionType> weaponProgressionTypes;

    public float GetStat(Stat stat, BaseSkill weapon)
    {

        ProgressionStat weaponStat = weaponProgressionTypes.Find(w => w.weaponType == weapon.weaponType).stats.Find(s => s.stat == stat);
        if (weaponStat == null)
        {
          return 0;
        }
        if (weapon.Level < weaponStat.Levels.Length)
        {
            return weaponStat.Levels[weapon.Level - 1];
        }
        else
        {
          return weaponStat.Levels[weaponStat.Levels.Length - 1];
        }
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
        public float[] Levels;
    }
}
