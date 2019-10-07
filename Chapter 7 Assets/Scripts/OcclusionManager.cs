using UnityEngine;
using System.Collections;

public class OcclusionManager : MonoBehaviour {
	
	public bool state; //active state to put the array elements into
	public GameObject[] newArea; // array for the other side of the gate

	// Use this for initialization
	void Start () {
//		for (int i = 0; i < newArea.Length; i++) {
//   			print (newArea [i].name); // print the name of element number i
//		}
//		print (""); // do a carriage return
//		
//		foreach(GameObject theElement in newArea) {
//		   print (theElement.name); // print the name of the current element
//		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// 
	void OnTriggerEnter (Collider defender) {
	  	if (defender.gameObject.tag == "Player") {
	    	foreach(GameObject theElement in newArea) {
   				theElement.SetActive(state); // set the object's active parameter to state
			}
 	   }
	}
	
}
