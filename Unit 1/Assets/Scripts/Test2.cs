using UnityEngine;
using System.Collections;

public class Test2 : MonoBehaviour {
	public float NextTime = 0f;
	public float Timer = 0.5f;
	public int iCounter = 10;
	public int MinHeight = 1;
	public int Maxheight = 10;
	public float HorizontalSpacing = 2f;
	public float VerticalSpacing = 1f;

	// Use this for initialization
	void Start () {
              }
	
	// Update is called once per frame
	void Update () {
			if (iCounter > 0 && Time.fixedTime > NextTime) {
			NextTime = Time.fixedTime + Timer;
			for (int j = 10; j > 0; j--)
			{
				int randomNumber = Random.Range (MinHeight, Maxheight);
				for (int i = 0; i < randomNumber; i++)
				{
					GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
					box.transform.position = new Vector3(iCounter * HorizontalSpacing, i * VerticalSpacing, j*HorizontalSpacing);

				}
			}
			iCounter--;
		}
	}

}
