using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzlehint : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI hintText;

    private float timeTillGone;
    void Start()
    {
        
    }

    void Update()
    {
        timeTillGone += Time.deltaTime;
        hintText.text = "Destroy the Shields";
        if (timeTillGone >= 3)
        {
            hintText.text = "";
        }
    }
}
