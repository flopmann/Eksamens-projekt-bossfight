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
    [Header("Symbol Health")]
    public static int Symbol1Health = 400;
    public static int Symbol2Health = 400;
    public static int Symbol3Health = 400;
    public static int Symbol4Health = 400;


    private GameObject currentSymbolBoss;  
    private GameObject currentSymbolStage;

    public static int currentSymbol;

    bool activeSymbol;

    private float timeTillNewSymbol = 10f;



    void Start()
    {
        activeSymbol = false;
    }

    
    void Update()
    {
        if (timeTillNewSymbol <= 0f)
        {
            chooseSymbol();
            activeSymbol = true;
            timeTillNewSymbol = 10f;  
        }
        if (activeSymbol == true)
        {
            activateSymbol();
            activeSymbol = false;
        }
        if (activeSymbol == false)
        {
            timeTillNewSymbol -= Time.deltaTime;
        }
        if (timeTillNewSymbol <= 1f)
        {
            deActivateSymbol();
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
            if (Symbol1Health <= 400)
            {
                currentSymbolBoss = Instantiate(Symbol1, symbol1Boss.position, Quaternion.identity);
                currentSymbolStage = Instantiate(Symbol1, symbol1Stage.position, Quaternion.identity);
            }
            if (Symbol1Health <= 0)
            {
                activeSymbol = false;
            }
        }
        if (currentSymbol == 2)
        {
            if (Symbol2Health <= 400)
            {
                currentSymbolBoss = Instantiate(Symbol2, symbol2Boss.position, Quaternion.identity);
                currentSymbolStage = Instantiate(Symbol2, symbol2Stage.position, Quaternion.identity);
            }
            if (Symbol2Health <= 0)
            {
                activeSymbol = false;
            }
        }
        if (currentSymbol == 3)
        {
            if (Symbol3Health <= 400)
            {
                currentSymbolBoss = Instantiate(Symbol3, symbol3Boss.position, Quaternion.identity);
                currentSymbolStage = Instantiate(Symbol3, symbol3Stage.position, Quaternion.identity);
            }
            if (Symbol3Health <= 0)
            {
                activeSymbol = false;
            }
        }
        if (currentSymbol == 4)
        {
            if (Symbol4Health <= 400)
            {
                currentSymbolBoss = Instantiate(Symbol4, symbol4Boss.position, Quaternion.identity);
                currentSymbolStage = Instantiate(Symbol4, symbol4Stage.position, Quaternion.identity);
            }
            if (Symbol4Health <= 0)
            {
                activeSymbol = false;
            }
        }

    }
    void deActivateSymbol()
    {
        //Destroy(Symbol1);
        //Destroy(Symbol2);
        //Destroy(Symbol3);
        //Destroy(Symbol4);
        Destroy(currentSymbolBoss);
        Destroy(currentSymbolStage);

    }

    

}
