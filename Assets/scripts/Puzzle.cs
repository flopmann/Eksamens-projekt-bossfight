using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [Header("Symbol Boss")]
    public Transform symbol1Boss;
    public Transform symbol2Boss;
    public Transform symbol3Boss;  
    public Transform symbol4Boss;
    [Header("Symbol Stage")]
    public Transform symbol1Stage;
    public Transform symbol2Stage;
    public Transform symbol3Stage;
    public Transform symbol4Stage;
    [Header("Symbols")]
    public GameObject Symbol1;
    public GameObject Symbol2;
    public GameObject Symbol3;
    public GameObject Symbol4;


    private GameObject currentSymbolBoss;  
    private GameObject currentSymbolStage;

    private int currentSymbol;

    bool activeSymbol;

    private float timeTillNewSymbol = 5;



    void Start()
    {
        activeSymbol = false;
    }

    
    void Update()
    {
        if (activeSymbol == false)
        {
            chooseSymbol();
            activeSymbol = true;
            timeTillNewSymbol = 5;  
        }
        if (activeSymbol == true)
        {
            timeTillNewSymbol -= Time.deltaTime;
        }
        if (timeTillNewSymbol <= 0)
        {
            activeSymbol = false;
        }

    }
    void chooseSymbol()
    {
        currentSymbol = UnityEngine.Random.Range(1, 5);
        Debug.Log(currentSymbol);
    }

    void activateSymbol()
    {
        if (currentSymbol == 1)
        {
            currentSymbolBoss = Instantiate(Symbol1, symbol1Boss.position, Quaternion.identity);
            currentSymbolStage = Instantiate(Symbol1, symbol1Stage.position, Quaternion.identity);
        }
        if (currentSymbol == 2)
        {
            currentSymbolBoss = Instantiate(Symbol2, symbol1Boss.position, Quaternion.identity);
            currentSymbolStage = Instantiate(Symbol2, symbol1Stage.position, Quaternion.identity);
        }
        if (currentSymbol == 3)
        {
            currentSymbolBoss = Instantiate(Symbol3, symbol1Boss.position, Quaternion.identity);
            currentSymbolStage = Instantiate(Symbol3, symbol1Stage.position, Quaternion.identity);
        }
        if (currentSymbol == 4)
        {
            currentSymbolBoss = Instantiate(Symbol4, symbol1Boss.position, Quaternion.identity);
            currentSymbolStage = Instantiate(Symbol4, symbol1Stage.position, Quaternion.identity);
        }

    }

}
