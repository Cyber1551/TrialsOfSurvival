using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image foreground;
    [SerializeField] private float positionOffset;
    [SerializeField] private float updateSpeedSeconds = 0.2f;
    [SerializeField] private EnemyHealth health;
    
    
    public void SetHealth(EnemyHealth health)
    {
        this.health = health;
        this.health.OnHealthChanged += HandleHealthChanged;
    }
    private  void HandleHealthChanged(int Hp, int MaxHealth, int amount, bool isCrit)
    {
        float hpPercent = (float)Hp / (float)MaxHealth;
        Vector3 randomPos = new Vector3(Random.Range(-1.5f, 1.5f), 2.25f, Random.Range(0f, 0.25f));
        DamagePopup.Create(health.transform.position + randomPos, transform.parent, amount, isCrit);
        StartCoroutine(ChangeToPct(hpPercent));
    }
    private IEnumerator ChangeToPct(float pc)
    {
       
        float preChangePct = foreground.fillAmount;
        float elapsed = 0f;
        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foreground.fillAmount = Mathf.Lerp(preChangePct, pc, elapsed / updateSpeedSeconds);
            yield return null;
        }
        foreground.fillAmount = pc;
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(health.transform.position + Vector3.up * positionOffset);
        
    }
    private void OnDestroy()
    {
        health.OnHealthChanged -= HandleHealthChanged;
    }
}
