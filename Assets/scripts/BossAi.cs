using System;
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
    public Animator animator;
    public float timeTillAttack = 1.5f;
    public float rangedRange = 20f;
    

    public bool stage1;
    bool rangedTargetSpawned;
    bool meleeTargetSpawned;

    private float timeTillSwitch = 5f;

    bool hasPicked;

    private int meleeOrRanged;

    public static int BossStage;

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
        animator = GetComponent<Animator>();
        stage1 = true;
        rangedTargetSpawned = false;
        hasPicked = false;
        meleeTargetSpawned = false;
        
    }

   
    void Update()
    {
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
        if (Puzzle.Symbol1Health == 0 && Puzzle.Symbol1Health == 0 && Puzzle.Symbol3Health == 0 && Puzzle.Symbol4Health == 0)
        {
            timeTillSwitch -= Time.deltaTime;
            if (timeTillSwitch <= 0f)
            {
                stage1 = false;
                BossStage = 2;
            }
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
        timeTillChase = 10f;
        timeTillAttack = 3f;

         

        if (stage1 == false) 
        {
            if (hasPicked == false)
            {
                meleeOrRanged = UnityEngine.Random.Range(1, 3);
                Debug.Log(meleeOrRanged);
                hasPicked = true;
            }

            if ((Target.transform.position - transform.position).magnitude <= rangedRange && meleeOrRanged == 1)
            {
                Currentstate = BossState.Rangedattacking;
            }
            
           if ((Target.transform.position - transform.position).magnitude <= meleeRange && meleeOrRanged == 2)
            {
                Currentstate = BossState.Meleeattacking;
            }

        }

        if ((Target.transform.position - transform.position).magnitude <= meleeRange)
        {
            Currentstate = BossState.Meleeattacking;
        }
        

    }
    void meleeAttacking()
    {
        
        if ((Target.transform.position-transform.position).magnitude >= meleeRange) 
        {
            timeTillChase -= Time.deltaTime;
            if(timeTillChase <= 0f)
            {
                if(stage1 == false)
                {
                    hasPicked = false;
                    Currentstate = BossState.Moving;
                }
                Currentstate = BossState.Moving;
                
            }
        }
        
        timeTillAttack -= Time.deltaTime;
        if (timeTillAttack <= 0)
        {
            GetComponent<MeleeAttack>().spawnTarget();
            meleeTargetSpawned = true;

        }
        if (meleeTargetSpawned == true)
        {
            meleeTargetSpawned = false;
            GetComponent<MeleeAttack>().meleeAttack();
            timeTillAttack = 5f;
            GetComponent<AIMove>().currentSpeed = 0f;
        }
       
    }
    void rangedAttacking()
    {
        Debug.Log("Attacking");
        timeTillAttack -= Time.deltaTime;

        if ((Target.transform.position - transform.position).magnitude >= rangedRange)
        {
            hasPicked = false;
            Currentstate = BossState.Moving;
        }

        if(timeTillAttack <= 0)
        {
            GetComponent<rangedAttack>().spawnTarget();
            rangedTargetSpawned = true;
        }
        if (rangedTargetSpawned == true)
        {

            timeTillAttack = 3;
            rangedTargetSpawned = false;
            GetComponent<rangedAttack>().spawnHitBox();


        }
    }

    
}
