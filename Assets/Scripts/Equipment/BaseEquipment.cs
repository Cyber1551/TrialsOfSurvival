using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum EquipmentType
{
    Axe, 
    Pickaxe
}
[CreateAssetMenu(menuName = "Tools/Base Equipment")]
public class BaseEquipment : ScriptableObject
{
    public string Name;
    public EquipmentType equipmentType;
    public AnimationClip animation;
    public AnimationClip idle;
    public bool locksMotion; 
    public int Damage; // To Tree, rock, enemey, etc 
}
