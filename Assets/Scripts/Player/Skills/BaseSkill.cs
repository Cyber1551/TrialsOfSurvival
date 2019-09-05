using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseSkill
{
    public WeaponType weaponType;
    public int MaxLevel;
    public int Level;
    public int MaxExp;
    public int Exp;

    public bool AddExp()
    {
        Exp++;
        if (Exp >= MaxExp && Level < MaxLevel)
        {
            LevelUp();
            return true;
        }
        return false; 
    }
    private void LevelUp()
    {
        Exp = 0;
        MaxExp += 3;
        Level++; 
    }
}
