using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    private CharacterController controller;
    public Animator animator;
    private Vector3 Target;
    public Transform Player;

    private float currentSpeed = 0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    
    void Update()
    {
        moveAi();
    }

   public void moveAi()
    {
        Target = Player.position;

        float distance = (Target -transform.position).magnitude;

        currentSpeed = moveSpeed;

        Vector3 newPosition = Vector3.MoveTowards(transform.position, Target, currentSpeed * Time.deltaTime);
        transform.position = newPosition;        
    }
}
