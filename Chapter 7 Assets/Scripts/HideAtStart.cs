using UnityEngine;
using System.Collections;

public class HideAtStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false); //deactivate the object this script is on
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
