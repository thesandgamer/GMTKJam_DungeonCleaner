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
    private void Awake()
    {
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
       // Debug.Log(axisValues);
        _moveInput = axisValues;
        Run();
    }


    void Run()
    {
        Vector2 targetSpeed = _moveInput * Data.runMaxSpeed;
        float accelRate;
        accelRate = (Mathf.Abs(targetSpeed.x) > 0.01f) ? Data.runAccelAmount : Data.runDeccelAmount;
        Vector2 speedDif;
        if (RB)
        {
            speedDif = targetSpeed - new Vector2(RB.velocity.x,RB.velocity.z);
        }
        else
        {
            speedDif = targetSpeed - new Vector2(RB2D.velocity.x,RB2D.velocity.y);
        }
        Vector2 movement = speedDif * accelRate;
        //Debug.Log("Movement: " + movement);
        if (RB)
        {
            RB.AddForce(new Vector3(movement.x,0,movement.y), ForceMode.Force);
        }
        else
        {
            RB2D.AddForce(new Vector3(movement.x,movement.y,0));
        }


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
