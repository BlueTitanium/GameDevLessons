using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMove : MonoBehaviour
{
    public float rotSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl)){
            transform.Rotate(1*rotSpeed,0,0);
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            transform.Rotate(-1*rotSpeed,0,0);
        }
        transform.eulerAngles.x = Mathf.Clamp(transform.eulerAngles.x, -60, 60);
    }
}
