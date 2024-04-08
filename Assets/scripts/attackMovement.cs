using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attackMovement : MonoBehaviour
{
    private Vector3 Target;
    public Transform attackTarget;
    public float attackSpeed = 80f;
    public int attackDamage = 25;

    public static int Health = 200;
    void Update()
    {
        attackMove();
        
    }
    public void attackMove()
    {
        Target = attackTarget.position;

        Vector3 newPosition = Vector3.MoveTowards(transform.position, Target, attackSpeed*Time.deltaTime);
        transform.position = newPosition;

        //if (transform.position == attackTarget.position)
        //{
          //  Destroy(gameObject);
        //}

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            Health = Health - attackDamage;
            Destroy(gameObject);
            Debug.Log(Health);
        }
    }

}
