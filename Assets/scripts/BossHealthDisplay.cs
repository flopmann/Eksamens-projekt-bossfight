using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class BossHealth1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI BossHealthText;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        BossHealthText.text = BossHealth.health.ToString();
    }
}
