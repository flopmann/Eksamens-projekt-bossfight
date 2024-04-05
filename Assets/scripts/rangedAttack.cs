using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedAttack : MonoBehaviour
{
    public GameObject rangedHitBox;
    public GameObject Target;
    private GameObject currentTarget;

    public Transform attackPoint;
    public Transform attackTarget;


    public void spawnTarget()
    {
        currentTarget = Instantiate(Target,attackTarget.position, Quaternion.identity);

    }

    public void spawnHitBox()
    {
        
        GameObject currentHitBox = Instantiate(rangedHitBox, attackPoint.position, Quaternion.identity);
        currentHitBox.GetComponent<rangedMovement>().attackTarget = currentTarget.transform; 

    }

}
