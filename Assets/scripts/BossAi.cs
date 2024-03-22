using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    private BossState Currentstate = BossState.Idle;

    public Transform Target;
    public float meleeRange = 10;
    public float timeTillStart = 10f;
    public float timeTillChase = 3f;

    public enum BossState
    {
        Moving,
        Idle, 
        Meleeattacking, 
        Rangedattacking,
    }
    void Start()
    {
        Currentstate = BossState.Idle;
      
    }

   
    void Update()
    {
        transform.forward = Target.transform.position;
        switch (Currentstate)
        {
            case BossState.Idle:
                 idleState();
                break;
            case BossState.Moving:
                 moving(); 
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
        timeTillStart -= Time.deltaTime;
        if (timeTillStart <= 0f)
        {
            Currentstate = BossState.Moving;
        }
    }
    
    void moving()
    {
        Debug.Log(Currentstate);
        GetComponent<AIMove>().moveAi();
        timeTillChase = 3f;
        if ((Target.transform.position - transform.position).magnitude <= meleeRange)
        {
            Currentstate = BossState.Meleeattacking;
        }
    }
    void meleeAttacking()
    {
        Debug.Log("attacking");
        if ((Target.transform.position-transform.position).magnitude >= meleeRange) 
        {
            timeTillChase -= Time.deltaTime;
            if(timeTillChase <= 0f)
            {
                Currentstate = BossState.Moving;
            }
        }
    }
    void rangedAttacking()
    {

    }
}
