using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;    
    private Vector3 Target;
    public Transform Player;
    public float currentSpeed;
    public float stage2Speed;

    
    public Transform target;


    public float speed = 1.0f;

    NavMeshAgent agent;


     void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //target.y = transform.position.y;
    }

    void Update()
    {
        Vector3 targetDirection = target.position - transform.position; 
        
        float singleStep = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }


  

    public void moveAi()
    {
        //Target = Player.position;
        //Target.y = transform.position.y;
        //Debug.Log("Trying to move");

        //if (BossAi.BossStage != 2)
        //{
        //  currentSpeed = moveSpeed;
        //}
        //if (BossAi.BossStage == 2)
        //{
        //  currentSpeed = stage2Speed;
        //}

        //Vector3 newPosition = Vector3.MoveTowards(transform.position, Target, currentSpeed * Time.deltaTime);
        //transform.position = newPosition;
        agent.SetDestination(target.position);

    }
}
