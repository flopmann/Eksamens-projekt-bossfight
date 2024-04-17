using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HealthText;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        HealthText.text = MeleeAttack.Health.ToString();
    }
}
