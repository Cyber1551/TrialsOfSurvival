using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Sword,
    Bow
}
public enum Stat
{
    Health,
    Damage,
    AttackSpeed,
    CritDamage, 
    CritChance 
}


public class BaseStats : MonoBehaviour
{
    [SerializeField] WeaponType CurrentWeapon;
    [SerializeField] List<BaseSkill> WeaponLevels;
    [SerializeField] PlayerProgression Progression;

    private void Awake()
    {
        WeaponLevels.ForEach(weapon =>
        {
            weapon.Level = 1;                             
            weapon.MaxExp = 5;
        });
    }
    public bool AddExp()
    {
        return WeaponLevels.Find(weapon => weapon.weaponType == CurrentWeapon).AddExp();
    }
    public int GetStat(Stat stat)
    {
        return Progression.GetStat(stat, WeaponLevels.Find(weapon => weapon.weaponType == CurrentWeapon));
    }
}
