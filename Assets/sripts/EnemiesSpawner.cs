using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField]
    List<Transform> listEnemiesPosTransforms;
    [SerializeField]
    GameObject enemyPrefab;
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
            int posIndex = Random.RandomRange(0, listEnemiesPosTransforms.Count);
            Instantiate(enemyPrefab, listEnemiesPosTransforms[posIndex].position, enemyPrefab.transform.rotation);
            timeSpawner = 0;
        }
    }
}
