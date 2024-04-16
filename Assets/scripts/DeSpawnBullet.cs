using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnBullet : MonoBehaviour
{
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag != "boss")
        {
            Destroy(gameObject);
        }
    }
}
