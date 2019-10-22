using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMove : MonoBehaviour
{
    public float rotSpeed = 1f;
    float xrot=0;
    public GameObject gnome;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl)){
            xrot += (1*rotSpeed);
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            xrot += (-1*rotSpeed);
        }
        xrot = Mathf.Clamp(xrot, -60, 60);
        transform.eulerAngles = new Vector3(xrot,gnome.transform.eulerAngles.y,0);
    }
}
