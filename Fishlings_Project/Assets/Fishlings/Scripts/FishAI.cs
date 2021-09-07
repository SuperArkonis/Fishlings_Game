using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform lure;

    public LayerMask whatWater, whatLure;

    //Patrol
    public Vector3 swimPoint;
    bool swimPointSet;
    public float swimPointRange;

    //Attract

    //States
    public float sightRange, attractRange;
    public bool lureInSight, lureInChase;


    void Awake()
    {
        lure = GameObject.Find("Bobber").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Check for sight range
        lureInSight = Physics.CheckSphere(transform.position, sightRange, whatLure);
        //lureInChase = Physics.CheckSphere(transform.position, attractRange, whatLure);

        if(!lureInSight)// && !lureInChase)
        {
            Patrol();
        }
        else
        {
            ChaseLure();
        }
    }

    void Patrol()
    {
        if(!swimPointSet)
        {
            SearchSwimPoint();
        }

        if(swimPointSet)
        {
            agent.SetDestination(swimPoint);
        }

        Vector3 distanceToSwimPoint = transform.position - swimPoint;

        //swim point reached
        if(distanceToSwimPoint.magnitude < 3f)
        {
            swimPointSet = false;
        }
    }

    void SearchSwimPoint()
    {
        
        //float randomZ = Random.Range(-swimPointRange, swimPointRange);
        //float randomX = Random.Range(-swimPointRange, swimPointRange);

        //swimPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        Vector2 randPoint = Random.insideUnitCircle * swimPointRange;
        //Debug.Log(randPoint);
        swimPoint = new Vector3(randPoint.x + transform.position.x, transform.position.y, randPoint.y + transform.position.z);

        if(Physics.Raycast((swimPoint+Vector3.up*5f), Vector3.down, 8f, whatWater))
        {
            swimPointSet = true;
        }
    }

    void ChaseLure()
    {
        agent.SetDestination(lure.position);
    }

    void OnDrawGizmosSelected() 
    {
        if (swimPointSet)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(swimPoint, 0.3f);
        }    
    }
}
