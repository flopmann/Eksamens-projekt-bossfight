using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackMovement : MonoBehaviour
{
    private Vector3 Target;
    public Transform attackTarget;
    public float attackSpeed = 5f;


    void Update()
    {
        attackMove();
    }
    public void attackMove()
    {
        Target = attackTarget.position;

        Vector3 newPosition = Vector3.MoveTowards(transform.position, Target, attackSpeed*Time.deltaTime);
        transform.position = newPosition;

        if (transform.position == attackTarget.position)
        {
            Destroy(gameObject);
        }

    }
}
