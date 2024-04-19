using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Removetext : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (BossHealth.Dead == 2)
        {
            Destroy(gameObject);
        }
    }
}
