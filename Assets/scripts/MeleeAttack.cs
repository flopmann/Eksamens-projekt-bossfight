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
        
        readyToAttack = false;
        Debug.Log("attacking");
        GameObject currentHitBox = Instantiate(meleeHitBox, attackPoint.position, Quaternion.identity);
        currentHitBox.GetComponent<attackMovement>().attackTarget = attackTarget;
    }   

    
   

}
