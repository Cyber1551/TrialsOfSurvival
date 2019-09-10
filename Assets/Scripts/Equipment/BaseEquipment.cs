using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

[CreateAssetMenu(menuName = "Tools/Base Equipment")]
public class BaseEquipment : ScriptableObject
{
    public string Name;
    public WeaponType equipmentType;
    public bool locksMotion;
    public int Damage; // To Tree, rock, enemey, etc
    public float AttackSpeed = 0.8f;
}
