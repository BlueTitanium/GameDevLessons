using UnityEngine;
using System.Collections;

public class DistanceDetector : MonoBehaviour {
	
	public Transform targetTransform; // the gnome's transform
	public Transform theCamera; // the camera's transform
	Vector2 source; // the gateway
	Vector2 target; // the gnome

	// Use this for initialization
	void Start () {
		// assign the x and z position to the source var
		source = new Vector2(transform.position.x,transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		// update the target's location
		target = new Vector2(targetTransform.position.x,targetTransform.position.z);
		// get the distance between the target and source
		float dist = Vector3.Distance(source, target); 
		
		if (dist < 3.0f && dist > 0.5f) {
		   //print (dist);
			Vector3 pos = theCamera.transform.localPosition; // make a variable to hold the current local position of the camera
			pos.z = 3.0f - dist; // assign the inverse of the distance to the z part of the temporary variable
			theCamera.transform.localPosition = pos; // assign the new position

		}
		//else print (""); // clear the status line
 
	
	}
}
