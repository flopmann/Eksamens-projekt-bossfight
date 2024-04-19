using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzlehint : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI hintText;

    
    void Start()
    {
        
    }

    void Update()
    {
        if (Crystalmovement.TrapTriggered == 1)
        {
            hintText.text = "Steal the crystal";
        }
        if (Crystalmovement.TrapTriggered == 2)
        {
            hintText.text = "Destroy the Shields";
        }
        if (BossAi.BossStage == 2)
        {
            hintText.text = "";
        }
        if (BossHealth.health <= 0)
        {
            hintText.text = "Steal the crystal";
        }
        if (CrystalPickup.CrystalPickedUp == 2)
        {
            hintText.text = "Escape!";
        }
    }
}
