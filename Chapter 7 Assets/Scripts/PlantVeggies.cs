using UnityEngine;
using System.Collections;

public class PlantVeggies : MonoBehaviour {
	
	public GameObject veggie; // the plant prefab
	float minX; // variables to hold the object's bounding box location
	float minZ;
	public bool rotate; // flag to rotate the rows to match the bed
	public int rows = 6; // the number of rows to make
	public int columns = 6; // number of columns to make
	float spacingX; 
	float spacingZ;
	public int percent = 20; // good starting percent of missing plants

	// Use this for initialization
	void Start () {
		// calculate box position
		minX = transform.position.x - transform.localScale.x/2;
		minZ = transform.position.z - transform.localScale.z/2;
		spacingX = transform.localScale.x / rows;
		spacingZ = transform.localScale.z / columns;
		
		PopulateBed(); // plant the Veggies
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void PopulateBed () {
	
		float y = transform.position.y; // ground level
		for (int x = 0; x < columns; x++) {
		   for (int z = 0; z < rows; z++) {
		        Vector3 pos = new Vector3(x * spacingX + minX + spacingX / 2, y, z * spacingZ + minZ + spacingZ / 2);
				int rPercent = Random.Range (1,101); // 1-100%
				if (rPercent > percent) { // plant the plant
			        GameObject newVeggie = (GameObject) Instantiate(veggie, pos, Quaternion.identity);
					
					// assign a random rotation to the clone		
					Vector3 rot = newVeggie.transform.localEulerAngles; // make a variable to hold the current local Euler (x,y,z) rotation
					rot.y = Random.Range(1,361); // assign a random rotation to the y part of the temporary variable
					newVeggie.transform.localEulerAngles = rot; // assign the new rotation
					
					// assign a random scale to the clone		
					Vector3 scale = newVeggie.transform.localScale; // variable to hold the current local scale 
					float rScale =  Random.Range(0.5f,1.2f);
					scale = new Vector3(rScale,rScale,rScale);
					newVeggie.transform.localScale = scale; // assign the new rotation
					
					newVeggie.transform.parent = transform; // assign the clone to this object
					
				}
		  }
		}
	}
	
	
}
