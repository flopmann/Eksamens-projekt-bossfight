using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private float health = 2000;
    private float deathTimer = 5;
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
        if (health <= 0)
        {
            dying = true;
        }

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
        Debug.Log("collision");
        if (col.gameObject.tag == "bullet" && BossAi.BossStage == 2)
        {
            health = health - 20;
            Debug.Log(health);
        }
    }
}
