using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    List<Transform> listEnemiesPosTransforms;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < listEnemiesPosTransforms.Count; i++)
        {
            Instantiate(enemyPrefab, listEnemiesPosTransforms[i].position, enemyPrefab.transform.rotation);
        }
    }
}
