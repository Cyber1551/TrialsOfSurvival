using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player Progression", menuName = "Stats/Player Progression", order = 0)]
public class PlayerProgression : ScriptableObject
{
    [SerializeField] List<WeaponProgressionType> weaponProgressionTypes = null;

    public int GetHealth(BaseSkill weapon)
    {
        return weaponProgressionTypes.Find(w => w.weaponType == weapon.weaponType).Health[weapon.Level - 1];
    }
    [System.Serializable]
    class WeaponProgressionType
    {
        public WeaponType weaponType;
        public int[] Health;
    }
}
