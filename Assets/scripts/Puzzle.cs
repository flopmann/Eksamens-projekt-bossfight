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
    [Header("non active boss symbol")]
    public GameObject BossSymbol1;
    public GameObject BossSymbol2;
    public GameObject BossSymbol3;
    public GameObject BossSymbol4;
    [Header("Dead stage symbol")]
    public GameObject Dead1;
    public GameObject Dead2;
    public GameObject Dead3;
    public GameObject Dead4;



    private GameObject currentSymbolBoss;  
    private GameObject currentSymbolStage;

    public static int currentSymbol;

    bool activeSymbol;

    private float timeTillNewSymbol = 10f;



    void Start()
    {
        timeTillNewSymbol = 0f;
    }

    
    void Update()
    {
        if (timeTillNewSymbol <= 0f)
        {
            chooseSymbol();
            activeSymbol = true;
            timeTillNewSymbol = 20f;  
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
        killShield();
        destroyRings();
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
                
                currentSymbolStage = Instantiate(Symbol1, symbol1Stage.position, symbol1Stage.rotation);
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
                
                currentSymbolStage = Instantiate(Symbol2, symbol2Stage.position, symbol2Stage.rotation);
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
                
                currentSymbolStage = Instantiate(Symbol3, symbol3Stage.position, symbol3Stage.rotation);
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
                
                currentSymbolStage = Instantiate(Symbol4, symbol4Stage.position, symbol4Stage.rotation);
            }
            if (Symbol4Health <= 0)
            {
                activeSymbol = false;
            }
        }

    }
    void deActivateSymbol()
    {
        
        Destroy(currentSymbolBoss);
        Destroy(currentSymbolStage);

    }

    void destroyRings()
    {
        if (Symbol1Health == 0)
        {
            Destroy(BossSymbol1);
        }
        if (Symbol2Health == 0)
        {
            Destroy(BossSymbol2);
        }
        if (Symbol3Health == 0)
        {
            Destroy(BossSymbol3);
        }
        if (Symbol4Health == 0)
        {
            Destroy(BossSymbol4);
        }
    }

    void killShield()
    {
        if (Symbol1Health <= 0)
        {
            Instantiate(Dead1, symbol1Stage.position, symbol1Stage.rotation);
        }
        if (Symbol2Health <= 0)
        {
            Instantiate(Dead2, symbol2Stage.position, symbol2Stage.rotation);
        }
        if (Symbol3Health <= 0)
        {
            Instantiate(Dead3, symbol3Stage.position, symbol3Stage.rotation);
        }
        if (Symbol4Health <= 0)
        {
            Instantiate(Dead4, symbol4Stage.position, symbol4Stage.rotation);
        }
    }

}
