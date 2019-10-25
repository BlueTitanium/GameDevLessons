using UnityEngine;
using System.Collections;

public class PotatoLauncher : MonoBehaviour {
	
	public GameObject projectile; // the projectile prefab
	public float speed = 20f; // give speed a default of 20 
	float loadRate = 0.1f; // how often a new projectile can be fired
	float timeRemaining; // how much time before the next shot can happen
	public Camera camera1;
	public Camera camera2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		timeRemaining -= Time.deltaTime; //
		// if the Fire1 button (default is left ctrl) is pressed and the alloted time has passed
		if (Input.GetKey (KeyCode.Mouse0) && timeRemaining <= 0) { 
		   timeRemaining = loadRate; // reset the time remaining
		   ShootProjectile ();// …shoot the projectile
			GetComponent<AudioSource>().Play (); // play the default audio clip on this component's gameObject
		}
		if(Input.GetKey(KeyCode.Mouse1)){
			camera1.gameObject.SetActive(false);
			camera2.gameObject.SetActive(true);
		}
		else{
			camera2.gameObject.SetActive(false);
			camera1.gameObject.SetActive(true);
		}
	
	}
	
	void ShootProjectile () {  
	   // create a clone of the projectile at the location & orientation of the script's parent     
	   GameObject potato = (GameObject) Instantiate (projectile, transform.position, transform.rotation);
	   // add some force to send the projectile off in its forward direction
	   potato.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3 (0,0,speed));
	}

}
