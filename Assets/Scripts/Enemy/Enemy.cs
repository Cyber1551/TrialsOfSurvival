using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
   
    private void OnParticleCollision(GameObject other)
    {
        InitDamage(null);
    }
    public void OnTriggerEnter(Collider other)
    {
       
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


        int damage = Mathf.RoundToInt(player.GetStat("PhysicalDamage").Value);
        int chance = Random.Range(0, 100);
        bool isCrit = false;
        if (chance <= player.GetStat("CritChance").Value)
        {
            isCrit = true;
            Debug.Log(player.GetStat("CritDamage").Value / 100);
            damage += Mathf.RoundToInt((float)damage * ((float)player.GetStat("CritDamage").Value / 100));
            player.GetStat("PhysicalDamage").Value *= 2;
            player.GetStat("CritChance").Value += 5;
        }
        float ls = player.GetStat("LifeSteal").Value;
        
        if (ls > 0 && player.playerHealth.Health < player.playerHealth.MaxHealth)
        {
            int lsAmount = Mathf.RoundToInt((ls / 100) * damage);
            if (lsAmount > 0)
            {
                player.playerHealth.HealDamage(lsAmount, isCrit);
            }
           
        }
        GetComponent<EnemyHealth>().TakeDamage(damage, isCrit);
    }
}

 
