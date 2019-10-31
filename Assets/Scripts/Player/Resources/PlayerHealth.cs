using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int BaseMaxHealth = int.MaxValue;
    public int MaxHealth;
    public int Health;
    bool isDead = false;
    public PlayerHealthBar HealthBar;

    public event Action<int, int, int, bool, bool> OnPlayerHealthChanged = delegate { };

    private void OnEnable()
    {
        HealthBar.SetHealth(this);
        //MaxHealth = BaseMaxHealth + (int)Mathf.Round(GetComponent<BaseStats>().GetStat(Stat.Health));
        Health = MaxHealth;
        HealthBar.UpdateMaxHealth(Health, MaxHealth);
    }
    public void HealDamage(int amount, bool isCrit)
    {

        Health += amount;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        OnPlayerHealthChanged(Health, MaxHealth, amount, isCrit, true);
        
    }
    public void TakeDamage(int amount, bool isCrit)
    {

        Health -= amount;
        OnPlayerHealthChanged(Health, MaxHealth, amount, isCrit, false);
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    
}
