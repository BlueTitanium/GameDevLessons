using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    bool dying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dying && transform.localScale != new Vector3(0f, 0f, 0f)){
            transform.localScale -= new Vector3(.05f, .05f, .05f);
        }
        if(transform.localScale == new Vector3(0f, 0f, 0f)){
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemies"){
            dying = true;
            other.gameObject.SetActive(false);
        }
    }
}
