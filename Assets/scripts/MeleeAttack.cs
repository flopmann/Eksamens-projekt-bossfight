using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject meleeHitBox;
    public float attackSpeed = 5f;
    public float attackTime;
    public float attackCooldown;
    public float attackDamage;
    public Transform attackPoint;
    private Vector3 Target;
    public Transform attackTarget;
    


    public bool readyToAttack;
    void Start()
    {
        readyToAttack = true;
    }
    
    void Update()
    {
        
    }

    public void meleeAttack()
    {
        Target = attackTarget.position;
        readyToAttack = false;
        Debug.Log("attacking");
        GameObject currentHitBox = Instantiate(meleeHitBox, attackPoint.position, Quaternion.identity);

        Vector3 hitBoxMovement = Vector3.MoveTowards(currentHitBox.transform.position, Target, attackSpeed * Time.deltaTime);
        currentHitBox.transform.position = hitBoxMovement;

    }

    public void hitBoxMovement()
    {
        

        
    }
   

}
