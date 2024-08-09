using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed = 2;
    [SerializeField]
    float timeRemain = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IEDestroy());
    }

    IEnumerator IEDestroy()
    {
        yield return new WaitForSeconds(timeRemain);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }
}
