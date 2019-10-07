using UnityEngine;
using System.Collections;

public class UpdateTests : MonoBehaviour {
	
	//int counter = 1;
	public float speed = 0.5f;
	bool allClear = false; // flag to activate the translate
	public bool stopIt = false; // flag to stop translate after object is underway
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//counter++; // increment the counter by 1
		//print (counter);
		
		//rotate the object on the world Y or up axis if the y rotation is less than 270 degrees
		if(transform.localEulerAngles.y < 270) {
			transform.Rotate(Vector3.up * Time.deltaTime * 20f, Space.World); // speed it up by 20f
		}		
		
		// adjust the rotation and set the allClear flag if over 270 
		if(transform.localEulerAngles.y > 270) {
			Vector3 rot = transform.localEulerAngles; //create a temp variable to store the rotation
			rot.y = 270f; // change the y part of the variable
			transform.localEulerAngles = rot; // update the rotation to the temp variable's value
			allClear = true; // set the flag to true
		}
		
		// Move the object forward along its z axis 1 unit/second * speed
		if (allClear && !stopIt) {
			transform.Translate(-Vector3.right * Time.deltaTime * speed);
		}

	}
	
	void ToggleStopIt (bool newState) {
			
	   stopIt = newState; // update the variable's state
	}
	
	
}
