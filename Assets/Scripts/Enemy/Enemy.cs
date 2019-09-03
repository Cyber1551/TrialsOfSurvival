using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    [RequireComponent(typeof(EnemyHealth))]
    public class Enemy : MonoBehaviour
    {

        public void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("Weapon"))
            {
                if (other.gameObject.GetComponentInParent<BaseStats>().AddExp())
                {
                    other.gameObject.GetComponentInParent<PlayerHealth>().UpdateHealth();
                }
                int damage = other.gameObject.GetComponent<Equipment>().equipment.Damage;
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
    }
