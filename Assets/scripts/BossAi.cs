using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    private BossState Currentstate = BossState.Idle;

    public LayerMask player, whatIsGround;

    public enum BossState
    {
        Moving,
        Idle, 
        Meleeattacking, 
        Rangedattacking,
        Patroling,
    }
    void Start()
    {
        Currentstate = BossState.Patroling;


    }

    // Update is called once per frame
    void Update()
    {
        switch (Currentstate)
        {
            case BossState.Idle:
                 idleState();
                 break;

            case BossState.Patroling:
                 patrolingState();
                 break;
            case BossState.Moving:
                 movingState(); 
                 break;
            case BossState.Meleeattacking:
                 meleeAttacking();
                 break;
            case BossState.Rangedattacking:
                 rangedAttacking();
                 break;
        }
    }

    void idleState()
    {

    }
    void patrolingState()
    {
        Collider[] VisionRange = Physics.OverlapSphere(transform.position, 5f);
        foreach (Collider collider in VisionRange)
        {
            if(collider.tag == "PLayer")
            {
                transform.forward = GameObject.FindGameObjectWithTag("Player").transform.position;
            }
        }


    }
    void movingState()
    {

    }
    void meleeAttacking()
    {

    }
    void rangedAttacking()
    {

    }
}
