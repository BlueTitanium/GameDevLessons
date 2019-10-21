using UnityEngine;
using System.Collections;

public class SimpleCharacterController : MonoBehaviour {
	
	Animator animator; // the Animator paramtercomponent/ state engine
	public float rotSpeed = 2f;
	Rigidbody rb3d;
	int rand = 0;
	int rAngle = 0;
	float timer = 0f;
	float maxtime = 1f;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>(); // assign the animator
		rb3d = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if(timer <= 0f){
			timer = maxtime;
			rand = Random.Range(-1,1);
			rAngle = Random.Range(-1,1);
		}else{
			timer -= Time.deltaTime;
		}
		if (animator) {
			if(rand == 0){
				animator.SetBool("Dance", true);
			} else {
				animator.SetBool("Dance", false);
			}
		    animator.SetFloat("Input V", (float)rand);
		}
		transform.Rotate(0,rAngle*rotSpeed,0);
	}
	
}
