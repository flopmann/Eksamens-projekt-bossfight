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
        transform.LookAt(Target);

        Vector3 newPosition = Vector3.MoveTowards(transform.position, Target, attackSpeed * Time.deltaTime);
        transform.position = newPosition;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (BossAi.BossStage != 2)
            {
                MeleeAttack.Health = MeleeAttack.Health - attackDamage;
                //Destroy(gameObject);
                Debug.Log(MeleeAttack.Health);
            }
            else
            {
                MeleeAttack.Health = MeleeAttack.Health - attackDamage*2;
                //Destroy(gameObject);
                Debug.Log(MeleeAttack.Health);
            }
        }
        
    }


}
