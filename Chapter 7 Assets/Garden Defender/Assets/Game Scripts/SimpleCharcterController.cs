using UnityEngine;
using System.Collections;

public class SimpleCharcterController : MonoBehaviour {
	
	Animator animator; // the Animator paramtercomponent/ state engine
	public float rotSpeed = 2f;
	Rigidbody rb3d;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>(); // assign the animator
		rb3d = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if (animator) {
			if(Input.GetKey("space")){
				animator.SetBool("Dance", true);
				rb3d.AddForce(0,15f,0);
			} else {
				animator.SetBool("Dance", false);
			}
			float v = Input.GetAxis("Vertical");
			
		    animator.SetFloat("Input V", v);
		    print (v); // see what the v input value sent to the animator
		}
		if(Input.GetKey("a")){
			transform.Rotate(0,-1*rotSpeed,0);
		}
		if(Input.GetKey("d")){
			transform.Rotate(0,rotSpeed,0);
		}
	}
	
}
