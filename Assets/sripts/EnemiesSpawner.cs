using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    List<GameObject> listEnemiesWavesPrefabs;
    [SerializeField]
    List<Transform> listEnemiesPosTranform;
    [SerializeField]
    float timeSpawnerMax = 2;
    float timeSpawner;
    // Start is called before the first frame update
    void Start()
    {
        timeSpawner = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSpawner < timeSpawnerMax)
        {
            timeSpawner += Time.deltaTime;
        }
        else
        {
            //create enemy
            //int posIndex = Random.Range(0, listEnemiesWavesPrefabs.Count);
            //Instantiate(listEnemiesWavesPrefabs[posIndex], transform.position, listEnemiesWavesPrefabs[posIndex].transform.rotation);
            int posIndex = Random.Range(0, listEnemiesPosTranform.Count);
            Instantiate(enemyPrefab, listEnemiesPosTranform[posIndex].position, enemyPrefab.transform.rotation);
            timeSpawner = 0;
        }
    }
}
