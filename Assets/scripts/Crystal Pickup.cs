using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public bool CrystalPickedUp;
    void Start()
    {
        CrystalPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && BossHealth.health <= 0) 
        {
            Destroy(gameObject);
            CrystalPickedUp = true;
        }
    }
}
