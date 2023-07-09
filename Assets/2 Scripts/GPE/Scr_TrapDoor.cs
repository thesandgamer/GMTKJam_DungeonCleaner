using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_TrapDoor : Scr_Interactible
{
    [SerializeField] private Scr_TrapDoor trapGoTo;
    private GameObject player;
    private S_Move_Phyiscs movement;

    private void Awake()
    {
        player = FindObjectOfType<Scr_PlayerManager>().gameObject;
        movement = FindObjectOfType<S_Move_Phyiscs>();
    }

    public override void Interacted(GameObject objectInteractedWith)
    {
        if (player.GetComponent<Scr_SwitchForm>().form == state.SMALL)
        {
            Debug.Log(player.name);
            Invoke("Teleport",1.5f);
            player.GetComponent<S_Move_Phyiscs>().Immobilise();
            GoToTrapDoor();
            Invoke("GoToTrapDoor",.1f);

            Invoke("ExitTrapDoor",2);
        }
    }

    private void GoToTrapDoor()
    {
        movement.Immobilise();
    }

    private void ExitTrapDoor()
    {
        movement.Remobilise();
    }

    private void Teleport()
    {
        player.transform.position = trapGoTo.transform.position;

    }
}
