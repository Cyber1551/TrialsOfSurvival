using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHealth : MonoBehaviour
{
    public static event Action<EnemyHealth> OnHealthAdded = delegate { };
    public static event Action<EnemyHealth> OnHealthRemoved = delegate { };

    private const float DUMMY_REST = 3f;
    public int MaxHealth;
    public int Hp;
    public BaseEnemy stats;

    public event Action<int, int, int, bool, bool> OnHealthChanged = delegate { };
    public int dmg = 1;
    public int chance = 1;
    private WaveSpawner spawner;
    private float dummyResetTimer = 0;
    
    private void OnEnable()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<WaveSpawner>();
        stats = spawner.GetRandomEnemyType();
        MaxHealth = spawner.CurrentWave.Number * stats.BaseHealthPerLevel;
        Hp = MaxHealth;
       
    }
    private void Start()
    {
        OnHealthAdded(this);
    }
    public void HealDamage(int amount, bool isCrit)
    {
        Hp += amount;
        if (Hp > MaxHealth)
        {
            Hp = MaxHealth;
        }
        OnHealthChanged(Hp, MaxHealth, amount, isCrit, true);
        
    }
    public void TakeDamage(int amount, bool isCrit)
    {
        Hp -= amount;
        dummyResetTimer = 0;
        OnHealthChanged(Hp, MaxHealth, amount, isCrit, false); 
        if (Hp <= 0)
        {
            if (!gameObject.CompareTag("Dummy"))
            {
                GameObject.FindGameObjectWithTag("Spawner").GetComponent<WaveSpawner>().RemoveEnemy();
                Destroy(this.gameObject);
            }
            
        }
    }
    private void Update()
    {
        if(gameObject.CompareTag("Dummy"))
        {
            if (dummyResetTimer > DUMMY_REST)
            {
                
                int a = MaxHealth - Hp;
                if (a == 0) return;
                Hp = MaxHealth;
                OnHealthChanged(Hp, MaxHealth, a, false, true);
                dummyResetTimer = 0;
            }
            dummyResetTimer += Time.deltaTime;
        }
    }
    private void OnDisable()
    {
        OnHealthRemoved(this);
    }
}
