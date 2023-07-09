using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(S_PlayerController))]
public class S_Move_Phyiscs : MonoBehaviour
{
    private S_PlayerController pc;
    
    [SerializeField] private Data_Movement_Physics Data;
    public Rigidbody RB { get; private set; }
    public Rigidbody2D RB2D { get; private set; }

    private Vector2 _moveInput;

    private bool canMove = true;

    [SerializeField] private GameObject body;

    public float currentSpeed ;

    [SerializeField] private Animator _animator;


    public void Immobilise()
    {
        canMove = false;
        _moveInput = Vector2.zero;
        RB2D.velocity = Vector2.zero;

    }

    public void Remobilise()
    {
        canMove = true;
        _moveInput = Vector2.zero;
        RB2D.velocity = Vector2.zero;



    }
    
    private void Awake()
    {
        currentSpeed = Data.runMaxSpeed;
        
        pc = GetComponent<S_PlayerController>();

        if (GetComponent<Rigidbody2D>())
        {
            RB2D = GetComponent<Rigidbody2D>();
        }
        else if (transform.parent.GetComponent<Rigidbody2D>())
        {
            RB2D = transform.parent.GetComponent<Rigidbody2D>();
        }

    }


    private void Move(Vector2 axisValues)
    {

        if (!canMove) return;
       // Debug.Log(axisValues);
        _moveInput = axisValues;
        
        if (axisValues != Vector2.zero)
        {
            _animator.speed = 1;
        }
        else
        {
            _animator.speed = 0;
        }
        
        if (axisValues.x != 0)
        {
           // body.flipY = axisValues.normalized.x > 0 ? false : true;

            float value = axisValues.normalized.x > 0 ? .3f : -.3f; 
            body.transform.localScale = new Vector3(value,body.transform.localScale.y,body.transform.localScale.z);

        }
        Run();
    }


    void Run()
    {
        Vector2 targetSpeed = _moveInput * currentSpeed;
        Vector2 accelRate;
        float accX =(Mathf.Abs(targetSpeed.x) > 0.01f) ? Data.runAccelAmount : Data.runDeccelAmount;
        float accY =(Mathf.Abs(targetSpeed.y) > 0.01f) ? Data.runAccelAmount : Data.runDeccelAmount;
        accelRate = new Vector2(accX,accY);
        
        Vector2 speedDif;

        
        speedDif = targetSpeed - new Vector2(RB2D.velocity.x,RB2D.velocity.y);
        Vector2 movement = speedDif * accelRate;
        //Debug.Log("Movement: " + movement);
        
        RB2D.AddForce(new Vector2(movement.x,movement.y));
        


    }
    
    
    private void OnEnable()
    {
        pc.ev_Move += ctx => Move(ctx);
    }
    private void OnDisable()
    {
        pc.ev_Move -= ctx => Move(ctx);
    }
    
}
