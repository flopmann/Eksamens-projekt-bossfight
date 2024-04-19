using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public static int health = 2000;
    
    



    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);

        }

      
    }

     void OnCollisionEnter(Collision col)
    {
        Debug.Log("collision");
        if (col.gameObject.tag == "bullet" && BossAi.BossStage == 2)
        {
            health = health - 20;
            Debug.Log(health);
        }
    }
}
