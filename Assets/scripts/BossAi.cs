using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class BossAi : MonoBehaviour
{
    private BossState Currentstate = BossState.Idle;

    public Transform Target;
    public float meleeRange = 5;
    public float timeTillStart = 10f;
    public float timeTillChase = 1;
    public Animator animator;
    public float timeTillAttack = 1f;
    public float rangedRange = 20f;
    public float timeTillRangedAttack = 4f;

    public bool stage1;
    bool rangedTargetSpawned;

    public AudioSource bosswalkAudio;

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
        stage1 = false;
        rangedTargetSpawned = false;
        hasPicked = false;
        BossStage = 1;
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
        if (Puzzle.Symbol1Health <= 0 && Puzzle.Symbol1Health <= 0 && Puzzle.Symbol3Health <= 0 && Puzzle.Symbol4Health <= 0)
        {
            timeTillSwitch -= Time.deltaTime;
            if (timeTillSwitch <= 0f)
            {
                stage1 = false;         
            }
        }
        if (stage1 == false)
        {
            BossStage = 2;
        }
        meleeOrRanged = 1;

        if (Currentstate==BossState.Moving)
        {
            bosswalkAudio.enabled = true;
        }
        else
        {
            bosswalkAudio.enabled = false;
        }
    }

    void idleState()
    {
        animator.SetBool("isIdle", true);
        timeTillStart -= Time.deltaTime;
        if (timeTillStart <= 0f)
        {
            Currentstate = BossState.Moving;
        }
    }
    
    void moving()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isWalking", true);

        
        //Debug.Log(Currentstate);
        GetComponent<AIMove>().moveAi();
        timeTillChase = 1f;
        timeTillAttack = 1f;

         

        if (stage1 == false) 
        {
            if (hasPicked == false)
            {
                //meleeOrRanged = UnityEngine.Random.Range(1, 3);
                //Debug.Log(meleeOrRanged);
                hasPicked = true;
            }
            if (meleeOrRanged == 1)
            {
                GetComponent<AIMove>().agent.stoppingDistance = rangedRange;
            }
            else
            {
                GetComponent<AIMove>().agent.stoppingDistance = meleeOrRanged;
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
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", true);

       

        if ((Target.transform.position-transform.position).magnitude >= meleeRange) 
        {
            
            timeTillChase -= Time.deltaTime;
            if(timeTillChase <= 0f)
            {
                
                if(stage1 == false)
                {
                    meleeOrRanged = 0;
                    hasPicked = false;
                    Currentstate = BossState.Moving;
                    animator.SetBool("isAttacking", false);
                }
                Currentstate = BossState.Moving;
                animator.SetBool("isAttacking", false);
            }
        }
        
        timeTillAttack -= Time.deltaTime;
        if (timeTillAttack <= 0)
        {
            timeTillAttack = 1f;
            

        }
       
        hasPicked = false;
    }
    void rangedAttacking()
    {
        animator.SetBool("isWalking", false);
        //Debug.Log("Attacking");
        timeTillRangedAttack -= Time.deltaTime;

        if ((Target.transform.position - transform.position).magnitude >= rangedRange)
        {
            meleeOrRanged = 0;
            hasPicked = false;
            Currentstate = BossState.Moving;
            animator.SetBool("isWalking", true);
            animator.SetBool("isThrowing", false);
        }

        if(timeTillRangedAttack <= 0)
        {
            GetComponent<rangedAttack>().spawnTarget();
            rangedTargetSpawned = true;
            animator.SetBool("isThrowing", true);
            StartCoroutine(SpawnProjectile());
        }
        if (rangedTargetSpawned == true)
        {

            timeTillRangedAttack = 4f;
            rangedTargetSpawned = false;
        }
        hasPicked = false;
    }

    IEnumerator SpawnProjectile()
    {
        yield return new WaitForSeconds(0.12f);
        // spawn projectile
        GetComponent<rangedAttack>().spawnHitBox();
    }
    
}
