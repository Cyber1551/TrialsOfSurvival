using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    public GameObject[] weapons;
    public Transform equipmentSpawn;
    private EquipmentAnimations animations;
    void Start()
    {
      animations = GetComponent<PlayerController>().animations;
    }
    public void SetEquipmentType(WeaponType type)
    {
      GetComponent<AnimationController>().SetWeaponType((int)type);
      GetComponent<BaseStats>().SetWeaponType(type);
      SpawnEquipment(type);
    }
    public void SpawnEquipment(WeaponType type)
    {
      RemoveCurrentEquipment();
       if (type != 0)
       {
          equipmentSpawn = GameObject.Find(animations.GetAnimation(type).spawnPoint).transform;
         GameObject go = Instantiate(weapons[((int)type) - 1], equipmentSpawn.position, equipmentSpawn.rotation, equipmentSpawn);
          go.transform.SetParent(equipmentSpawn);
          go.transform.localPosition = Vector3.zero;
          go.transform.localScale = new Vector3(3, 3, 3);
          go.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
       }

    }
    private void RemoveCurrentEquipment()
    {
      foreach(Transform t in equipmentSpawn)
      {
        GameObject.Destroy(t.gameObject);
      }
    }

}
