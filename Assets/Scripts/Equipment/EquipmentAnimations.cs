using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentAnimations", menuName = "Equipment/Animations")]
public class EquipmentAnimations : ScriptableObject
{
  [SerializeField] public List<WeaponAnimation> animations;

  [System.Serializable]
  public class WeaponAnimation
  {
    public WeaponType Type;
    public string spawnPoint;
    public List<AnimationClip> animations;
    public List<GameObject> helperObjects; //Projectiles, etc

  }

  public WeaponAnimation GetAnimation(WeaponType type)
  {
     return animations.Find(a => a.Type == type);
  }
}
