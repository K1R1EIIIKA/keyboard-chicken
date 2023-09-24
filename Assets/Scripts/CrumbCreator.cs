using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbCreator : MonoBehaviour
{
    [SerializeField] private CrumbSpawnConfig FirstLevel, SecondLevel, ThirdLevel, FourthLevel;

    [System.Serializable]
    class CrumbSpawnConfig
    {
        [SerializeField] public GameObject[] CrumbPrefabs;
        public GameObject[] crumbWithMass;
        [SerializeField] public float spawnDelay = 1;
        public int crumbToSpawnAmount = 1;
        public int coefficient = 3; //��� ��? p.s. Vlad
        private int _goodOrEvil;
    }

    private float randomY;
    Vector2 whereToSpawn;
    public float nextSpawn = 0.0f;
    [SerializeField] private Chicken chicken;

    CrumbSpawnConfig GetConfigLevel()
    {
        if (chicken != null)
        {
            switch (chicken.GetChickenSize())
            {
                case 0: return FirstLevel;
                case 1: return SecondLevel;
                case 2: return ThirdLevel;
                case 3: return FourthLevel;
                default: return null;
            }
        }
        else return null;
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            CrumbSpawnConfig CrumbConfig = GetConfigLevel();
            GameObject Enemy;

            for (int i = 0; i < Random.Range(1, CrumbConfig.crumbToSpawnAmount); i++)
            {
                nextSpawn = Time.time + CrumbConfig.spawnDelay;
                randomY = Random.Range(-4.5f, 4.5f);
                if (Random.Range(1, 11) < CrumbConfig.coefficient)
                {
                    whereToSpawn = new Vector2(transform.position.x, randomY);
                    Enemy = Instantiate(CrumbConfig.CrumbPrefabs[Random.Range(0, CrumbConfig.CrumbPrefabs.Length)],
                        whereToSpawn, Quaternion.identity);
                }
                else
                {
                    whereToSpawn = new Vector2(transform.position.x, randomY);
                    Enemy = Instantiate(CrumbConfig.crumbWithMass[Random.Range(0, CrumbConfig.crumbWithMass.Length)],
                        whereToSpawn, Quaternion.identity);
                }
                
                Destroy(Enemy, 6f);
            }
        }
    }
}