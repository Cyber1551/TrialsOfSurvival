using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int BaseMaxHealth = 100;
    public int MaxHealth;
    public int Health;
    bool isDead = false;
    public PlayerHealthBar HealthBar;

    public event Action<int, int, int, bool> OnHealthChanged = delegate { };

    private void OnEnable()
    {
        HealthBar.SetHealth(this);
        MaxHealth = BaseMaxHealth + (int)Mathf.Round(GetComponent<BaseStats>().GetStat(Stat.Health));
        Health = MaxHealth;
        HealthBar.UpdateMaxHealth(Health, MaxHealth);
    }
    public void TakeDamage(int amount, bool isCrit)
    {
        Health -= amount;
        OnHealthChanged(Health, MaxHealth, amount, isCrit);
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateHealth()
    {
        int currMaxHealth = MaxHealth;
        MaxHealth = BaseMaxHealth + (int)Mathf.Round(GetComponent<BaseStats>().GetStat(Stat.Health));

        int diff = MaxHealth - currMaxHealth;
        Debug.Log(diff);
        Health += diff;
        HealthBar.UpdateMaxHealth(Health, MaxHealth);
    }
}
