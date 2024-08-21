using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2;
    [SerializeField]
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var movement = new Vector3(h, 0, v);
        transform.Translate(moveSpeed * movement * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.World);
        transform.LookAt(tf);
    }
}
