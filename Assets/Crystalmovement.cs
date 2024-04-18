using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystalmovement : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;

    public float speed;

    public bool TrapTriggered;

    void Start()
    {
        TrapTriggered = false;
    }
    
    void Update()
    {
        if (BossHealth.health <= 0)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, Target2.position, speed * Time.deltaTime);

            transform.position = newPosition;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, Target1.position, speed * Time.deltaTime);

            transform.position = newPosition;

            TrapTriggered = true;

        }
        
    }

}
