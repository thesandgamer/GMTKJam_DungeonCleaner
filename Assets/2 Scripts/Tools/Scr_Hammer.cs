using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Hammer : Scr_Tool
{
    private int numberToActivateMax = 3;
    private int actualNumber = 0;
    
    private GameObject objectToRepair;
    
    public override void Clicked(GameObject on)
    {
    }

    public override void Pressed(GameObject on)
    {
        objectToRepair = on;
        if (!objectToRepair.GetComponent<Scr_BrokenObject>().broken) return;
        actualNumber++;
        print("Object bein repared");
        if (actualNumber >= numberToActivateMax)
        {
            Finish();
        }
    }

    public override void Released(GameObject on)
    {

    }

    public void Reset()
    {
        //Cache l'ui
        actualNumber = 0;
        objectToRepair = null;
        print("HAMMMER RESET");

    }


    void Finish()
    {
        objectToRepair.GetComponent<Scr_BrokenObject>().Interacted(gameObject);
    }
}
