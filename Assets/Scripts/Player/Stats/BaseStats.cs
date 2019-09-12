using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Unarmed = 0,
    Sword = 1,
    Bow = 2
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
    [SerializeField] public WeaponType CurrentWeapon;
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

    public void SetWeaponType(WeaponType type)
    {
      CurrentWeapon = type;
    }
    public bool AddExp()
    {
        return WeaponLevels.Find(weapon => weapon.weaponType == CurrentWeapon).AddExp();
    }
    public float GetStat(Stat stat)
    {

        return Progression.GetStat(stat, WeaponLevels.Find(weapon => weapon.weaponType == CurrentWeapon));
    }
}
