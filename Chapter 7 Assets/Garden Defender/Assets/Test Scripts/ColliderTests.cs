using UnityEngine;
using System.Collections;

public class ColliderTests : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision theVictim) {
	   if (theVictim.gameObject.tag != "Ignore") {
	      print (theVictim.gameObject.name + " got hit");
		  gameObject.SendMessage("ToggleStopIt", true);
	   }
	}
	
	void OnTriggerExit (Collider theVictim) {
	   if (theVictim.gameObject.tag != "Ignore") {
	      print (theVictim.gameObject.name + " got hit");
		  gameObject.SendMessage("ToggleStopIt", true);
	   }
	}
	
	
}
