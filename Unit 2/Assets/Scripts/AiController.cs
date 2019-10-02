using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class AiController : MonoBehaviour
{
    [SerializeField]
    Transform destination;
 
    NavMeshAgent navMeshagent;
   
    // Use this for initialization
    public void Start ()
    {
        navMeshagent = this.GetComponent<NavMeshAgent>();
        
    }
    public void Update()
    {
        SetDestination();
    }
 
    private void SetDestination()
    {
        if(destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navMeshagent.SetDestination(targetVector);
        }
    }
}