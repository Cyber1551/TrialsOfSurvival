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
        PlayerController player = GameAssets.I.player;
        BaseStats baseStats = player.GetComponent<BaseStats>();

        if (baseStats.AddExp())
        {
            player.GetComponent<PlayerHealth>().UpdateHealth();
        }
        
        int damage = (int)Mathf.Round(baseStats.GetStat(Stat.Damage));
        int chance = Random.Range(0, 100);
        bool isCrit = false;
        if (chance <= player.critChanceTest)
        {
            isCrit = true;
            damage += damage * 2;
            player.critChanceTest += 1;
        }
        GetComponent<EnemyHealth>().TakeDamage(damage, isCrit);
    }
}

 
