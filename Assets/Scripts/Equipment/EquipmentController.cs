using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    public GameObject[] weapons;
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
            foreach (string sp in animations.GetAnimation(type).spawnPoint)
            {
                Transform equipmentSpawn = GameObject.Find(sp).transform;
                GameObject go = Instantiate(weapons[((int)type)], equipmentSpawn.position, equipmentSpawn.rotation, equipmentSpawn);
                go.transform.SetParent(equipmentSpawn);
                go.transform.localPosition = Vector3.zero;
                go.transform.localScale = new Vector3(3, 3, 3);
                go.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
            GetComponent<PlayerController>().equippedWeapon = go.GetComponent<Equipment>().equipment;
            }
       

    }
    private void RemoveCurrentEquipment()
    {
        foreach (Transform t in GameObject.Find("Equipment Spawn Left Hand").transform)
        {
            Destroy(t.gameObject);
        }
        foreach (Transform t in GameObject.Find("Equipment Spawn Right Hand").transform)
        {
            Destroy(t.gameObject);
        }
    }

}
