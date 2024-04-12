using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    
    public Transform Player;
 
    
    public Transform target;


    public float speed = 1.0f;

    public NavMeshAgent agent;


     void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }
    void Update()
    {
        Vector3 targetDirection = target.position - transform.position; 
        
        float singleStep = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
        if (BossAi.BossStage == 2)
        {
            agent.speed = 10;   
        }
    }
    public void moveAi()
    {
        
        agent.SetDestination(target.position);

    }
}
