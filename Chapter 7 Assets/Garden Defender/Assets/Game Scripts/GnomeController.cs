using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeController : MonoBehaviour
{
    public float speed = 1f;
    public float rotSpeed = 1f;
    GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(manager.GetComponent<GameManager>().isPaused == false){
            if(Input.GetKey("a")){
                transform.Rotate(0,-1*rotSpeed,0);
            }
            if(Input.GetKey("d")){
                transform.Rotate(0,1*rotSpeed,0);
            }
            float zVal = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(0, 0, zVal) * speed);
        }
    }
}
