using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            MeleeAttack.Health = MeleeAttack.Health - 30;

            if (BossAi.BossStage == 2)
            {
                MeleeAttack.Health = MeleeAttack.Health - 30*2;
            }
        }
    }
}
