using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public GameObject Crystal;
    public static int CrystalPickedUp;
    void Start()
    {
        CrystalPickedUp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && BossHealth.health <= 0) 
        {
            CrystalPickedUp = 2;
            Destroy(Crystal);
        }
    }
}
