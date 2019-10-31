using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Image timeUntilWaveBar;
    public Text waveText;

    public Wave CurrentWave;
    private int EnemyCounter = 0;


    public List<BaseEnemy> EnemyTypes;
    public GameObject TestEnemy;
    // Start is called before the first frame update
    void Start()
    {
        CurrentWave = new Wave(1, 1, false);
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            StartSpawning();
        }
    }
    private void UpdateText()
    {
        waveText.text = "Wave " + CurrentWave.Number + "\n" + CurrentWave.numOfEnemies + "/" + CurrentWave.maxEnemies; 
    }
    public void RemoveEnemy()
    {
        CurrentWave.numOfEnemies--;
        if (CurrentWave.numOfEnemies <= 0)
        {
            NextWave();
        }
        UpdateText();
    }
    public void StartSpawning()
    {
        Debug.Log("SPAWNING");
        if(CurrentWave.hasStarted )
        {
            return;
        }
        else
        {
            CurrentWave.hasStarted = true;
            StartCoroutine(Spawn());
        }
        
        
    }
    private IEnumerator Spawn()
    {
        float delay = 1f;
        for (int i = 0; i < CurrentWave.numOfEnemies; i++)
        {
            GameObject enemy = Instantiate(TestEnemy, new Vector3(transform.position.x + Random.Range(-5, 5), 1, transform.position.z + Random.Range(-5, 5)), Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
    public BaseEnemy GetRandomEnemyType()
    {
        return EnemyTypes[Random.Range(0, EnemyTypes.Count)];
    }
    private void NextWave ()
    {
        int num = CurrentWave.Number + 1;
        int noE = 1 + Mathf.RoundToInt(num / 3) + EnemyCounter;
        EnemyCounter++;
        if (num % 5 == 0) EnemyCounter = 0;
        CurrentWave = new Wave(num, noE, (num % 10 == 0));
        UpdateText();
    }
         
    public class Wave
    {
        public int Number;
        public bool hasStarted;
        public int numOfEnemies;
        public bool bossWave;
        public readonly int maxEnemies;
        public Wave(int num, int noE, bool boss)
        {
            Number = num;
            hasStarted = false;
            numOfEnemies = noE;
            maxEnemies = numOfEnemies;
            bossWave = boss;
            
        }
    }
}
