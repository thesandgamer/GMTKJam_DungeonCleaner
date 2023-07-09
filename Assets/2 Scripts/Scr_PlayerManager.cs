using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scr_PlayerManager : MonoBehaviour
{
    //Si on est en train d'intéragir, on ne peut pas se déplacer 

    private S_Move_Phyiscs movement;
    private Scr_Interact interact;
    private Scr_PlayerManager _playerManager;
    private S_PlayerController pc;
    private void Awake()
    {
        movement = GetComponent<S_Move_Phyiscs>();
        interact = GetComponent<Scr_Interact>();
        pc = GetComponent<S_PlayerController>();
    }


    private void OnEnable()
    {
       // interact.ev_StartInteracting += StartInteracting;
       // interact.ev_StopInteracting += StopInteracting;
    }

    public void Immobilise()
    {
        movement.Immobilise();
        pc.immobilise = true;

        //Debug.Log("IMMOBILISE");
    }
    
    public void Remobilise()
    {
       movement.Remobilise();
       pc.immobilise = false;

       // Debug.Log("REMOBILISE");


    }

    private void OnDisable()
    {
        //interact.ev_StartInteracting -= StartInteracting;
       // interact.ev_StopInteracting -= StopInteracting;
    }
}
