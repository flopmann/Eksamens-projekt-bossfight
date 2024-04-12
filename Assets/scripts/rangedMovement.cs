using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class rangedMovement : MonoBehaviour
{
    public Transform attackTarget;

    public float attackSpeed;
    public int attackDamage = 30;

    private Vector3 Target;
  

    
    void Update()
    {
        attackMove();
        if (gameObject.transform.position == attackTarget.position)
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
                attackMovement.Health = attackMovement.Health - attackDamage;
                Destroy(gameObject);
                Debug.Log(attackMovement.Health);
            }
            else
            {
                attackMovement.Health = attackMovement.Health - attackDamage*2;
                Destroy(gameObject);
                Debug.Log(attackMovement.Health);
            }
        }
        
    }


}
