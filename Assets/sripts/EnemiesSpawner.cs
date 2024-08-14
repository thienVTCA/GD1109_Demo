using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> listEnemiesWavesPrefabs;
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
            int posIndex = Random.RandomRange(0, listEnemiesWavesPrefabs.Count);
            Instantiate(listEnemiesWavesPrefabs[posIndex], transform.position, listEnemiesWavesPrefabs[posIndex].transform.rotation);
            timeSpawner = 0;
        }
    }
}
