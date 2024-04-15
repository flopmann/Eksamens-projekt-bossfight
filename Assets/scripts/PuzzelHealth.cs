using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelHealth : MonoBehaviour
{

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "bullet")
        {
            if (Puzzle.currentSymbol == 1)
            {
                Puzzle.Symbol1Health = Puzzle.Symbol1Health - 40;
                Debug.Log(Puzzle.Symbol1Health);
            }
            if (Puzzle.currentSymbol == 2)
            {
                Puzzle.Symbol2Health = Puzzle.Symbol2Health - 40;
                Debug.Log(Puzzle.Symbol2Health);
            }
            if (Puzzle.currentSymbol == 3)
            {
                Puzzle.Symbol3Health = Puzzle.Symbol3Health - 40;
                Debug.Log(Puzzle.Symbol3Health);
            }
            if (Puzzle.currentSymbol == 4)
            {
                Puzzle.Symbol4Health = Puzzle.Symbol4Health - 40;
                Debug.Log(Puzzle.Symbol4Health);
            }
        }
        
    }
}
