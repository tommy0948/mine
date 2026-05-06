using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform[] spawnPoints;
    
    public int currentWave = 1;
    public int monstersPerWave = 5;
    public float timeBetweenSpawns = 1.5f;
    public float timeBetweenWaves = 5f;

    private bool isWaveActive = false;
    private int monstersAlive = 0;
    private Text waveUI;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        waveUI = FindObjectOfType<Text>();
        
        // 씬 시작 후 3초 뒤에 첫 웨이브 시작
        Invoke("StartNextWave", 3f);
    }

    public void StartNextWave()
    {
        if (!isWaveActive)
        {
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        isWaveActive = true;
        monstersAlive = 0;
        Debug.Log("웨이브 " + currentWave + " 시작!");
        UpdateWaveUI();

        for (int i = 0; i < monstersPerWave; i++)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject monster = Instantiate(monsterPrefab, randomSpawnPoint.position, Quaternion.identity);
            
            // 몬스터가 죽으면 카운트 감소
            Enemy enemy = monster.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.waveManager = this;
            }
            
            monstersAlive++;
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void MonsterDefeated()
    {
        monstersAlive--;
        
        if (monstersAlive <= 0 && isWaveActive)
        {
            isWaveActive = false;
            EndWave();
        }
    }

    void EndWave()
    {
        currentWave++;
        monstersPerWave = Mathf.Min(monstersPerWave + 3, 20); // 최대 20마리
        Debug.Log("웨이브 " + (currentWave - 1) + " 완료!");
        UpdateWaveUI();
        
        // 다음 웨이브 준비
        Invoke("StartNextWave", timeBetweenWaves);
    }

    void UpdateWaveUI()
    {
        if (waveUI != null)
        {
            waveUI.text = "Wave: " + currentWave + " | Monsters: " + monstersAlive;
        }
    }
}
