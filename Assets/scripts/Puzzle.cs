using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    
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
    [Header("non active stage Symbol")]
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;

   
    private GameObject currentSymbolStage;

    public static int currentSymbol = 4;

    bool activeSymbol;

    //private float timeTillNewSymbol;
    void Start()
    {
        //timeTillNewSymbol = 0f;
        activeSymbol = true;
    }

    
    void Update()
    {
       // if (timeTillNewSymbol <= 0f)
        //{
          //  ChooseSymbol();
            //activeSymbol = true;
            //timeTillNewSymbol = 10f;  
        //}
        if (activeSymbol == true)
        {
            ActivateSymbol();
            activeSymbol = false;
        }
        //if (activeSymbol == false)
        //{
         //   timeTillNewSymbol -= Time.deltaTime;
       // }
        //if (timeTillNewSymbol <= 1f)
        //{
         //   DeActivateSymbol();
       // }
        KillShield();
        DestroyRings();
        if (currentSymbol == 1 && Symbol1Health <= 0)
        {
            DeActivateSymbol();
            //timeTillNewSymbol = 0;
            currentSymbol = currentSymbol - 1;
            activeSymbol = true;
            Instantiate(Dead1, symbol1Stage.position, symbol1Stage.rotation);
            Destroy(Stage1);
        }
        if (currentSymbol == 2 && Symbol2Health <= 0)
        {
            DeActivateSymbol();
            //timeTillNewSymbol = 0;
            currentSymbol = currentSymbol - 1;
            activeSymbol = true;
            Instantiate(Dead2, symbol2Stage.position, symbol2Stage.rotation);
            Destroy(Stage2);
        }
        if (currentSymbol == 3 && Symbol3Health <= 0)
        {
            DeActivateSymbol();
            //timeTillNewSymbol = 0;
            currentSymbol = currentSymbol - 1;
            activeSymbol = true;
            Instantiate(Dead3, symbol3Stage.position, symbol3Stage.rotation);
            Destroy(Stage3);
        }
        if (currentSymbol == 4 && Symbol4Health <= 0)
        {
            DeActivateSymbol();
            //timeTillNewSymbol = 0;
            currentSymbol = currentSymbol - 1;
            activeSymbol = true;
            Instantiate(Dead4, symbol4Stage.position, symbol4Stage.rotation);
            Destroy(Stage4);
        }
    }
    void ChooseSymbol()
    {
        //currentSymbol = UnityEngine.Random.Range(1, 5);
        Debug.Log(currentSymbol);
    }

    void ActivateSymbol()
    {
        if (currentSymbol == 1)
        {
            if (Symbol1Health <= 400)
            {
                currentSymbolStage = Instantiate(Symbol1, symbol1Stage.position, symbol1Stage.rotation);
            }
            if (Symbol1Health <= 0)
            {
              //  timeTillNewSymbol = 0;
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
            //    timeTillNewSymbol = 0;
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
               // timeTillNewSymbol = 0;
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
             // timeTillNewSymbol = 0;              
            }
        }
    }
    void DeActivateSymbol()
    {    
        Destroy(currentSymbolStage);
    }

    void DestroyRings()
    {
        if (Symbol1Health <= 0)
        {
            Destroy(BossSymbol1);
        }
        if (Symbol2Health <= 0)
        {
            Destroy(BossSymbol2);
        }
        if (Symbol3Health <= 0)
        {
            Destroy(BossSymbol3);
        }
        if (Symbol4Health <= 0)
        {
            Destroy(BossSymbol4);
        }
    }

    void KillShield()
    {
        if (Symbol1Health <= 0)
        {
            
            
        }
        if (Symbol2Health <= 0)
        {
            
            
        }
        if (Symbol3Health <= 0)
        {
            
            
        }
        if (Symbol4Health <= 0)
        {
            
            
        }
    }


}
