using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2;
    public GameObject bulletPrefab;
    [SerializeField]
    Transform gunTransform;
    [SerializeField]
    float maxHealth = 20;
    float health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Contains("bulletEnemy"))
        {
            Debug.Log("player take dam");
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag.Contains("enemy"))
        {
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
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, gunTransform.position, bulletPrefab.transform.rotation);
        }
    }
}
