﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    public Transform manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Projectile"){
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            manager.GetComponent<GameManager>().score += 50f;
        }
    }
}
