using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private float health = 2000f;
    private float deathTimer = 5f;
    public Animator animator;

    private bool dying;



    void Start()
    {
        animator = GetComponent<Animator>();
        dying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dying == true)
        {
            deathTimer -= Time.deltaTime;
        }
        if (deathTimer <= 0f)
        {
            Destroy(gameObject);
        }

        
      
    }

     void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "bullet")
        {
            health = health - 20;
            Debug.Log(health);
        }
    }
}
