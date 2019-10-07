using UnityEngine;
using System.Collections;

public class SimpleCharcterController : MonoBehaviour {
	
	Animator animator; // the Animator paramtercomponent/ state engine
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>(); // assign the animator
	}
	
	// Update is called once per frame
	void Update () {
		if (animator) {
		
		   float v = Input.GetAxis("Vertical");
		   animator.SetFloat("Input V", v);
		   print (v); // see what the v input value sent to the animator
		}
	}
	
}
