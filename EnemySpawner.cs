using UnityEngine;
using System.Collections.Generic;
using System.Linq; // List 셔플을 위해 필요

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnInterval = 4f; 
    public int maxEnemies = 4;

    private float timer;
    private List<GameObject> activeEnemies = new List<GameObject>(); 
    
    // 0:상, 1:하, 2:좌, 3:우. 네 개의 경계를 모두 사용해야 하므로 리스트로 관리합니다.
    private List<int> spawnSides = new List<int> { 0, 1, 2, 3 };
    private int spawnIndex = 0; // 현재 소환할 경계의 인덱스

    private const float OutOfBoundsX = 13f; 
    private const float OutOfBoundsY = 6f; 

    void Start()
    {
        ShuffleSpawnSides(); // 게임 시작 시 순서 섞기
        SpawnEnemy();
    }

    void Update()
    {
        timer += Time.deltaTime;
        activeEnemies.RemoveAll(enemy => enemy == null);

        if (timer >= spawnInterval && activeEnemies.Count < maxEnemies)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void ShuffleSpawnSides()
    {
        System.Random rng = new System.Random();
        int n = spawnSides.Count;
        while (n > 1) 
        {
            n--;
            int k = rng.Next(n + 1);
            int value = spawnSides[k];
            spawnSides[k] = spawnSides[n];
            spawnSides[n] = value;
        }
    }

    void SpawnEnemy()
    {
        int side = spawnSides[spawnIndex];
        spawnIndex++;
        if (spawnIndex >= spawnSides.Count)
        {
            spawnIndex = 0;
            ShuffleSpawnSides(); 
        }

        Vector3 spawnPosition = Vector3.zero;

        if (side == 0) 
        {
            spawnPosition = new Vector3(Random.Range(-OutOfBoundsX + 1, OutOfBoundsX - 1), OutOfBoundsY, 0);
        }
        else if (side == 1) 
        {
            spawnPosition = new Vector3(Random.Range(-OutOfBoundsX + 1, OutOfBoundsX - 1), -OutOfBoundsY, 0);
        }
        else if (side == 2) 
        {
            spawnPosition = new Vector3(-OutOfBoundsX, Random.Range(-OutOfBoundsY + 1, OutOfBoundsY - 1), 0);
        }
        else 
        {
            spawnPosition = new Vector3(OutOfBoundsX, Random.Range(-OutOfBoundsY + 1, OutOfBoundsY - 1), 0);
        }

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        activeEnemies.Add(enemy);
        
        EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
        if (movement != null)
        {
            movement.InitializeMovement(side, OutOfBoundsX, OutOfBoundsY);
        }
    }
}
