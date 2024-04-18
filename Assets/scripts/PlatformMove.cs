using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    public Transform target;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (BossHealth.health <= 0 && CrystalPickup.CrystalPickedUp == 2)
        {
            movePlatform();
        }

    }

    void movePlatform()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        transform.position = newPosition;
    }
}
