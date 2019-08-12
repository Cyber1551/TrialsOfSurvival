using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    public GameObject equippedToolTest;
    public Transform equipmentSpawn;
    private void Start()
    {
       GameObject go = Instantiate(equippedToolTest, equipmentSpawn.position, equipmentSpawn.rotation, equipmentSpawn);
        go.transform.SetParent(equipmentSpawn);
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = new Vector3(3, 3, 3);
        go.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));

    }

}
