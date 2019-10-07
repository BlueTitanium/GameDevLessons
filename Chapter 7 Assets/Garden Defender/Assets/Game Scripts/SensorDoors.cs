using UnityEngine;
using System.Collections;

public class SensorDoors : MonoBehaviour {
	
	public AnimationClip clipOpen; // the open animation
	public AnimationClip clipClose; // the close animation
	//public SmoothFollow follow; // the camera' SmoothFollow script
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// open the gates
	void OnTriggerEnter (Collider defender) {
	   if (defender.gameObject.tag == "Player") {
	      GetComponent<Animation>().Play(clipOpen.name);
		  GetComponent<AudioSource>().Play(); // play the clip loaded in the audio component	
	   }
		//follow.distance = 1.15f; // change the SmoothFollow distance
		//follow.height = 0.5f; // change the SmoothFollow height

	}

	// close the gates
	void OnTriggerExit (Collider defender) {
	   if (defender.gameObject.tag == "Player") {
	      GetComponent<Animation>().Play(clipClose.name);
		  GetComponent<AudioSource>().Play(); // play the clip loaded in the audio component
	   }
		//follow.distance = 2.8f; // revert the SmoothFollow distance
		//follow.height = 1.8f; // revert the SmoothFollow height

	}

}
