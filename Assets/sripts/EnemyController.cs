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
    [SerializeField]
    float maxHealth = 20;
    float health;
    [SerializeField]
    List<AudioClip> listSounds;
    AudioSource soundSource;
    [SerializeField]
    GameObject hitEffectPrefab, explosionEffectPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        bulletTime = 0;
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("bulletPlayer"))
        {
            Instantiate(hitEffectPrefab, collision.transform.position, Quaternion.identity);
            soundSource.clip = listSounds[0];
            soundSource.Play();
            Debug.Log("enemy take dam");
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Instantiate(explosionEffectPrefab, collision.transform.position, Quaternion.identity);
                UIManager.uIManagerInstance.UpdateEnemiesKilledNumber();
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag.Contains("Player"))
        {
            Instantiate(explosionEffectPrefab, collision.transform.position, Quaternion.identity);
            UIManager.uIManagerInstance.UpdateEnemiesKilledNumber();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Contains("finish",System.StringComparison.OrdinalIgnoreCase))
        {
            Destroy(gameObject);
        }
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
            soundSource.clip = listSounds[1];
            soundSource.Play();
            Instantiate(bulletPrefab, gunTransform.position, bulletPrefab.transform.rotation);
            bulletTime = 0;
        }
    }
}
