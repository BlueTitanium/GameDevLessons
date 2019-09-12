using UnityEngine;
using System.Collections;

public class exampleScript : MonoBehaviour {
	public int numBoxes = 10;
	public float spacing = 1.41f;
	public GameObject[] boxes = new GameObject[10];

		
	// Use this for initialization
	void Start () {

		for (int i = 0; i < numBoxes; i++) {
			GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
			boxes [i] = box;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		int i = 0;

		foreach (GameObject go in boxes) {
			
			float wave = Mathf.Sin(Time.fixedTime + i);
			go.transform.position = new Vector3(i*spacing, wave, 0);
			i++;
			print (i);
			
		}
		
	}
}