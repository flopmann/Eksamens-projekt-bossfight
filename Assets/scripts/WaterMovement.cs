using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float speed;

    public Transform PlayerHead;

    public Transform Target;

    public float air = 100;
    void Start()
    {
        
    }

    
    void Update()
    {
        moveWater();
    }

    void moveWater()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, Target.position, speed*Time.deltaTime);

        transform.position = newPosition;
    }
    void Drowning()
    {
        if (transform.position.y < PlayerHead.position.y)
        {
            air -= Time.deltaTime;
        }
    }
}
