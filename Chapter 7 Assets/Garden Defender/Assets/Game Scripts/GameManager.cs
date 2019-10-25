using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform bunny;
    public Transform min;
    public Transform max;
    float minx, minz, maxx, maxz, y;
    float timer = 0f;
	float maxtime = .5f;
    float timerS = 0f;
    public float score = 0f;
    public float maxPlantScore = 0f;
    // Start is called before the first frame update
    void Start()
    {
        minx = min.transform.position.x;
        minz = min.transform.position.z;
        maxx = max.transform.position.x;
        maxz = max.transform.position.z;
        y = min.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {        
        if(timer <= 0f){
			timer = maxtime;
			Instantiate(bunny,new Vector3(Random.Range(minx,maxx),y,Random.Range(minz,maxz)), Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
		}else{
			timer -= Time.deltaTime;
		}
    }
}
