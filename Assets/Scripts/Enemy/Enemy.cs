using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Weapon"))
        {
            
            InitDamage(other);
        }
        if (other.gameObject.CompareTag("Projectile"))
        {
            InitDamage(other);
            Destroy(other.gameObject);
        }
    }

    private void InitDamage(Collider other)
    {
        if (GameAssets.I.player.GetComponent<BaseStats>().AddExp())
        {
            GameAssets.I.player.GetComponent<PlayerHealth>().UpdateHealth();
        }
        
        int damage = GameAssets.I.player.GetComponentInChildren<Equipment>().equipment.Damage + (int)Mathf.Round(GameAssets.I.player.GetComponent<BaseStats>().GetStat(Stat.Damage));
        int chance = Random.Range(0, 100);
        bool isCrit = false;
        if (chance <= GameAssets.I.player.critChanceTest)
        {
            isCrit = true;
            damage += damage * 2;
            GameAssets.I.player.critChanceTest += 1;
        }
        GetComponent<EnemyHealth>().TakeDamage(damage, isCrit);
    }
}

 
