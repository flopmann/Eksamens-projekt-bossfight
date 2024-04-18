using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystalmovement : MonoBehaviour
{
    public Transform Target1;
    

    public float speed;

    public static int TrapTriggered;

    void Start()
    {
        TrapTriggered = 1;
    }
    
    void Update()
    {
        
        if (TrapTriggered == 2 && BossHealth.health >= 0) 
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, Target1.position, speed * Time.deltaTime);

            transform.position = newPosition;

        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            TrapTriggered = 2;

            Debug.Log(TrapTriggered);

        }
        
    }

}
