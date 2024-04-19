using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class BossHealthDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI BossHealthText;
    


    void Start()
    {
        
    }

    
    void Update()
    {
        BossHealthText.text =  BossHealth.health.ToString();
        if (BossHealth.health <= 0)
        {
            Destroy(BossHealthText);
        }  
    }
}
