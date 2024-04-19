using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CrystalMoveback : MonoBehaviour
{
    public Transform Target;

    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossHealth.Dead == 2)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);

            transform.position = newPosition;
        }
    }
}
