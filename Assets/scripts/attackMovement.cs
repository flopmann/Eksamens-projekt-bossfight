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


    
    void Update()
    {
        attackMove();
        if (transform.position == attackTarget.position)
        {
            Destroy(gameObject);
        }
    }
    public void attackMove()
    {
        Target = attackTarget.position;

        Vector3 newPosition = Vector3.MoveTowards(transform.position, Target, attackSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            if (BossAi.BossStage != 2)
            {
                MeleeAttack.Health = MeleeAttack.Health - attackDamage;
                Destroy(gameObject);
                Debug.Log(MeleeAttack.Health);
            }
            else
            {
                MeleeAttack.Health = MeleeAttack.Health - attackDamage*2;
                Destroy(gameObject);
                Debug.Log(MeleeAttack.Health);
            }
        }
    }
}
