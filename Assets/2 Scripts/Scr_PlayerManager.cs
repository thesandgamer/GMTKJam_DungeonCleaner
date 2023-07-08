using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scr_PlayerManager : MonoBehaviour
{
    //Si on est en train d'intéragir, on ne peut pas se déplacer 

    private S_Move_Phyiscs movement;
    private Scr_Interact interact;
    private void Awake()
    {
        movement = GetComponent<S_Move_Phyiscs>();
        interact = GetComponent<Scr_Interact>();
    }


    private void OnEnable()
    {
        interact.ev_StartInteracting += StartInteracting;
        interact.ev_StartInteracting += StoptInteracting;
    }

    private void StartInteracting()
    {
        movement.Immobilise();
    }
    
    private void StoptInteracting()
    {
        movement.Remobilise();

    }

    private void OnDisable()
    {
        interact.ev_StartInteracting -= StartInteracting;
        interact.ev_StartInteracting -= StoptInteracting;
    }
}
