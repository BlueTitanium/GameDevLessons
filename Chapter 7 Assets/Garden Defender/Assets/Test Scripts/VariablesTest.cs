using UnityEngine;
using System.Collections;

public class VariablesTest : MonoBehaviour {
	
	public int legs = 4; // number of legs, will need to calculate speed
	public float earLength = 2.5f; // will need to calculate hearing distance
	public string description = ""; // will need for mouseover text
	public bool IsWarmBlooded; // also needed for speed calculation
	public GameObject favoriteFood; // objects that will be eaten within range
	public Camera theView; // a test for a Unity component
	public VariablesTest myCustomScript; // a test for a custom component
		
	
	
	// Use this for initialization
	void Start () {
		//if (legs == 1) {
		//   Debug.Log("The " + gameObject.name + " has " + legs + " leg.");
		//}
		//else {
		//   Debug.Log("The " + gameObject.name + " has " + legs + " legs.");
		//}
//		earLength += 2.0f;  // add to the value and re-assign it
//		print (earlength);
		favoriteFood = GameObject.Find("Carrots");
		//print("The " + gameObject.name + "'s favorite food is " + favoriteFood.name + ".");
		theView = GameObject.Find("Main Camera").GetComponent<Camera>(); 
		//myCustomScript = GameObject.Find("Walkway").GetComponent<VariablesTest>(); 
		myCustomScript = (VariablesTest) GameObject.Find("Walkway").GetComponent(typeof(VariablesTest));
		//print ("The view uses " + theView.gameObject.name);
		//print ("The script is from the " + myCustomScript.gameObject.name + " object");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
