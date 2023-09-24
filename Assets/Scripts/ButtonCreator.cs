using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonCreator : MonoBehaviour
{
    [SerializeField] private float StartSpawnDelay;
    [SerializeField] private EnemySpawnConfig FirstLevel,SecondLevel,ThirdLevel,FourthLevel;
    private float nextSpawnTime = 0;
    [SerializeField] private Chicken chicken;
    [System.Serializable]
    class EnemySpawnConfig
    {
        [SerializeField] public float MinSpawnDelay;
        [SerializeField] public float MaxSpawnDelay;
        [SerializeField] public float DamageDelay;
        [SerializeField] public GameObject[] EnemyButtons;
        [SerializeField] public float XSize;
        [SerializeField] public float YSize;
        [SerializeField] public Transform spawnZone;
    }
    void SpawnEnemy(EnemySpawnConfig LevelConfig)
    {
        float randomX = Random.Range(LevelConfig.spawnZone.position.x-LevelConfig.spawnZone.localScale.x/2f, LevelConfig.spawnZone.position.x + LevelConfig.spawnZone.localScale.x/2f);
        float randomY = Random.Range(LevelConfig.spawnZone.position.y - LevelConfig.spawnZone.localScale.y / 2f, LevelConfig.spawnZone.position.y + LevelConfig.spawnZone.localScale.y / 2f);
        Vector2 whereToSpawn = new Vector2(randomX, randomY);
        
        GameObject button = Instantiate(LevelConfig.EnemyButtons[Random.Range(0, LevelConfig.EnemyButtons.Length)], whereToSpawn, Quaternion.identity);
        
    }
    EnemySpawnConfig GetChickenLevel()
    {
        if (chicken != null)
        {
            switch (MenuNavigation.LevelNumber)
            {
                case 0: return FirstLevel;
                case 1: return SecondLevel;
                case 2: return ThirdLevel;
                case 3: return FourthLevel;
                default: return null;
            }
        }
        
        return null;
    }
    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            EnemySpawnConfig EnemyConfig = GetChickenLevel();
            if (EnemyConfig != null)
            {
                SpawnEnemy(EnemyConfig);
                nextSpawnTime = Time.time + Random.Range(EnemyConfig.MinSpawnDelay, EnemyConfig.MaxSpawnDelay);
            }
        }
    }
}
