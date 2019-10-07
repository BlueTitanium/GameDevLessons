using UnityEngine;
using System.Collections;

public class SpawnBunnies : MonoBehaviour {
	
	public GameObject zombieBunny; // the zombieBunny prefab
	public Transform currentZone; // the drop zone
	float minX; // variables to hold the object's bounding box location
	float maxX;
	float minZ;
	float maxZ;
	int litterSize = 8; // max number of zombie bunnies to instantiate each time
	float reproRate = 12f; // base time before respawning
	bool canReproduce = true; // flag to control reproduction of zombie bunnies
	int currentBunCount = 0; // current number of zombie bunnies
	public Transform bunHolder; // to parent the instantiated zombie bunnies to
	
	// Use this for initialization
	void Start () {
		
		minX = currentZone. position.x - currentZone. localScale.x/2;
		maxX = currentZone. position.x + currentZone. localScale.x/2;	
		minZ = currentZone. position.z - currentZone. localScale.z/2;
		maxZ = currentZone. position.z + currentZone. localScale.z/2;

		int tempLitterSize = litterSize * 3; // increased for first drop only
		PopulateGardenBunnies (tempLitterSize);  // create new zombie bunny prefabs in the scene
		float tempRate = reproRate * 2; // allow extra time before the first drop
		StartCoroutine(StartReproducing(tempRate)); // start the first timer- pass in reproRate seconds
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void PopulateGardenBunnies (int count) {
		
 		count = Random.Range(count*3/4,count +1); // randomize the count number
		currentBunCount += count; // add the lastest count to the current total
		print("zombie Bunnies = " + currentBunCount);

	    for (int i = 0; i < count; i++) {
		   // create new zombie bunny prefabs in the scene
		   GameObject zBunny = (GameObject) Instantiate(zombieBunny, new Vector3(Random.Range(minX,maxX), 1.0f, Random.Range(minZ,maxZ)), Quaternion.identity);
			
			Vector3 rot = zBunny.transform.localEulerAngles; // make a variable to hold the current local Euler (x,y,z) rotation
			rot.y = Random.Range(1,361); // assign a random rotation to the y part of the temporary variable
			zBunny.transform.localEulerAngles = rot; // assign the new rotation
			
			zBunny.GetComponent<Animator>().Play("Bunny Eat", 0, Random.Range(0.0f,1.0f));
			
			zBunny.transform.parent = bunHolder; // assign the clone to this object's transform 
		}

	}
	IEnumerator StartReproducing(float minTime) {
	   // wait for this much time before going on
	   float adjustedTime = Random.Range(minTime, minTime + 5f);
		
		yield return new WaitForSeconds(adjustedTime-3f); // pause 3 seconds before time's up
		GetComponent<AudioSource>().Play(); // play the sound effect that signals the repro populating
		yield return new WaitForSeconds(3f); // finish the adjusted time

	   // having waited, make more zombie bunnies
	   PopulateGardenBunnies (litterSize);
	   //and start the coroutine again, but only if there are enough left to reproduce…
	   if (canReproduce) StartCoroutine(StartReproducing(reproRate));
	}


	
}
