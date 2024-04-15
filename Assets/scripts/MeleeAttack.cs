using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeleeAttack : MonoBehaviour
{
    public GameObject meleeHitBox;
    public GameObject Target;
    private GameObject currentTarget;

    public Transform attackPoint;
    public Transform attackTarget;

    public static int Health = 200;




    public void spawnTarget()
    {

        currentTarget = Instantiate(Target, attackTarget.position, Quaternion.identity);

    }

    public void meleeAttack()
    {
        
        
        Debug.Log("attacking");
        GameObject currentHitBox = Instantiate(meleeHitBox, attackPoint.position, Quaternion.identity);
        currentHitBox.GetComponent<attackMovement>().attackTarget = currentTarget.transform;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (BossAi.BossStage != 2)
            {

            }
        }



    }


}
