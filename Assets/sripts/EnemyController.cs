using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float eneySpeed = 2;
    [SerializeField]
    Transform gunTransform;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float bulletSpawnTime = 2;
    float bulletTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        bulletTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * eneySpeed * Time.deltaTime);
        if(bulletTime < bulletSpawnTime)
        {
            bulletTime += Time.deltaTime;
        }
        else
        {
            Instantiate(bulletPrefab, gunTransform.position, bulletPrefab.transform.rotation);
            bulletTime = 0;
        }
    }
}
