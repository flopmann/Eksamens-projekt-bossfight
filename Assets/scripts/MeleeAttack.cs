using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class MeleeAttack : MonoBehaviour
{
    
    

    public static int Health = 200;

    private void Start()
    {
        Debug.Log("???");
    }
    void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene("DeathMenu");
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision with " + col.gameObject.name);
        if (col.gameObject.tag == "Player")
        {
            if (BossAi.BossStage != 2)
            {
                Health = Health - 25;
            }
            if (BossAi.BossStage == 2)
            {
                Health = Health - 25 * 2;
            }
            Debug.Log(Health);
        }



    }


}
