using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;    
    private Vector3 Target;
    public Transform Player;
    private float currentSpeed;
    void Start()
    {   
        

    }

    
    void Update()
    {
        
    }

   public void moveAi()
    {
        Target = Player.position;
        Debug.Log("Trying to move");
        

        currentSpeed = moveSpeed;

        Vector3 newPosition = Vector3.MoveTowards(transform.position, Target, currentSpeed * Time.deltaTime);
        transform.position = newPosition;        
    }
}
