using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_TrapActivator : Scr_Interactible
{
    [SerializeField] private Scr_Trap trap;
    

    public override void Interacted(GameObject objectInteractedWith)  
    {
        if (!trap.armed) //Si le piège n'est pas déjà armé
        {
            RearmTrap();
            Scr_AudioPlayer.Instance.PlayTrapActiveSound();
        }
        print(gameObject.name + "Have been interacted with" + (objectInteractedWith!=null ? objectInteractedWith.name : "nothing" ) );
        
    }


    private void RearmTrap()
    {
        trap.Rearm();
        GetComponent<BoxCollider2D>().enabled = false;

    }
}
