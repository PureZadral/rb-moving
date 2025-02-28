using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    Rigidbody rb;
    Transform trsf;
    float vertical;
    float horizontal;
    public float jump = 50f;
    bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trsf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        rb.AddRelativeForce(0, 0, vertical * 50f);
        trsf.Rotate(0, horizontal, 0);

        if(Input.GetKeyDown("space") && isGrounded == true){
            rb.AddForce(0, jump, 0, ForceMode.Impulse);
            rb.linearDamping = 2;
            rb.angularDamping = 2;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "ground"){
            isGrounded = true;
            rb.linearDamping = 0;
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if(coll.gameObject.tag == "ground"){
            isGrounded = false;
        }
    }
}
