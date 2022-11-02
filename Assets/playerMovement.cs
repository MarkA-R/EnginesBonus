using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    float jumpHeight = 30;
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = 1;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
        transform.position += velocity.normalized*speed*Time.deltaTime;
    }
}
