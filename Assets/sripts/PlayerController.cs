using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2;
    [SerializeField]
    float bulletSpawnTime = 2;
    public GameObject bulletPrefab;
    [SerializeField]
    Transform gunTransform;
    [SerializeField]
    float maxHealth = 20;
    float health;
    // Start is called before the first frame update
    [SerializeField]
    List<AudioClip> listSounds;
    AudioSource soundSource;
    [SerializeField]
    GameObject hitEffectPrefab, explosionEffectPrefab;

    EnemyController[] listEnemies;


    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        health = maxHealth;
        UIManager.uIManagerInstance.UpdatePlayerHealthSlider(1);
        StartCoroutine(IEShooting());
    }

    IEnumerator IEShooting()
    {
        yield return new WaitUntil(() => listEnemies != null && listEnemies.Length > 0);
        Debug.Log("IEShooting 1 player " + listEnemies.Length);
        while (true)
        {
            Instantiate(bulletPrefab, gunTransform.position, bulletPrefab.transform.rotation);
            yield return new WaitForSeconds(bulletSpawnTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("bulletEnemy"))
        {
            soundSource.clip = listSounds[0];
            soundSource.Play();
            Instantiate(hitEffectPrefab, collision.transform.position, Quaternion.identity);
            Debug.Log("player take dam");
            health--;
            UIManager.uIManagerInstance.UpdatePlayerHealthSlider(health / maxHealth);
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Instantiate(explosionEffectPrefab, collision.transform.position, Quaternion.identity);
                UIManager.uIManagerInstance.UpdatePlayerHealthSlider(0);
                UIManager.uIManagerInstance.GameOver();
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag.Equals("enemy"))
        {
            UIManager.uIManagerInstance.UpdatePlayerHealthSlider(0);
            Instantiate(explosionEffectPrefab, collision.transform.position, Quaternion.identity);
            UIManager.uIManagerInstance.GameOver();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var movement = new Vector3(h, 0, v);
        transform.Translate(moveSpeed * movement * Time.deltaTime);
        //if(listEnemies == null)
        listEnemies = GameObject.FindObjectsOfType<EnemyController>();
        //if(Input.GetMouseButtonDown(0))
        //{
        //    soundSource.clip = listSounds[1];
        //    soundSource.Play();
        //    Instantiate(bulletPrefab, gunTransform.position, bulletPrefab.transform.rotation);
        //}
    }
}
