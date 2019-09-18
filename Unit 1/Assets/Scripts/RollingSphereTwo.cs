using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSphereTwo : MonoBehaviour
{
    public float speed;
    public float flyspeed = .05f;
    private bool flying = false;
    private Rigidbody rb3d;

    // Start is called before the first frame update
    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xMove = Input.GetAxis("Horizontal");
        if(Input.GetKey("tab"))flying = !flying;
        float yMove = 0f;
        if(Input.GetKey("space"))yMove = 1;
        if(Input.GetKey("left shift"))yMove = -1;
        if(flying) rb3d.AddForce(-Physics.gravity, ForceMode.Acceleration);
        float zMove = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xMove, 0, zMove);
        rb3d.AddForce(movement * speed);
        transform.Translate(0f,yMove*flyspeed,0f);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Vanishing"))
            col.gameObject.SetActive(false);
    }
}
