using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public GameObject Crystal;
    public bool CrystalPickedUp;
    void Start()
    {
        CrystalPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && BossHealth.health <= 0) 
        {
            //Destroy(gameObject);
            CrystalPickedUp = true;
            Destroy(Crystal);
        }
    }
}
