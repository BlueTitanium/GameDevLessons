using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitControl : MonoBehaviour
{   
    public bool grounded;
    public LayerMask layer;
    public float speed = 1f;
    public float jumpForce = 20f;
    private Rigidbody rb3d;
    // Start is called before the first frame update
    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") *speed;
        float zMove = Input.GetAxis("Vertical") *speed;

        float yMove = 0f;
        if(Input.GetKey("space") && grounded)yMove = 1;

        rb3d.AddForce(0, jumpForce * yMove, 0);

        transform.Translate(xMove, 0, zMove);
        if(!Physics.CheckCapsule(GetComponent<Collider>().bounds.center,
                                new Vector3(GetComponent<Collider>().bounds.center.x,
                                GetComponent<Collider>().bounds.min.y-0.1f,
                                GetComponent<Collider>().bounds.center.z),
                                0.25f,
                                layer))
            grounded = false;
        else grounded = true;
    }
    
}
