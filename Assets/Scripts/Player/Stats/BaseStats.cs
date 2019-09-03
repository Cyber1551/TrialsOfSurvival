using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Sword,
    Bow
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
    public int GetHealth()
    {
        return Progression.GetHealth(WeaponLevels.Find(weapon => weapon.weaponType == CurrentWeapon));
    }
}
