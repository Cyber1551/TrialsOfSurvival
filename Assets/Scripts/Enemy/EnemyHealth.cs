using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHealth : MonoBehaviour
{
    public static event Action<EnemyHealth> OnHealthAdded = delegate { };
    public static event Action<EnemyHealth> OnHealthRemoved = delegate { };


    [SerializeField] private int MaxHealth;
    [SerializeField] private int Hp;
    public BaseEnemy stats;

    public event Action<int, int, int, bool> OnHealthChanged = delegate { };
    public int dmg = 1;
    public int chance = 1;
    private void OnEnable()
    {
        MaxHealth = stats.BaseHealth;
        Hp = MaxHealth;
        OnHealthAdded(this);  
    }
    public void TakeDamage(int amount, bool isCrit)
    {
        Hp -= amount;
        OnHealthChanged(Hp, MaxHealth, amount, isCrit); 
        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {

    }
    private void OnDisable()
    {
        OnHealthRemoved(this);
    }
}
