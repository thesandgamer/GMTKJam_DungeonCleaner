using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Hammer : Scr_Tool
{
    private int numberToActivateMax = 3;
    private int actualNumber = 0;
    
    private GameObject objectToRepair;

    private Scr_UIHammer _uiHammer;

    private void Awake()
    {
        _uiHammer = GetComponent<Scr_UIHammer>();
    }

    public override void Clicked(GameObject on)
    {
    }

    public override void Pressed(GameObject on)
    {
        if (!on.GetComponent<Scr_BrokenObject>().broken) return;
        objectToRepair = on;
        Scr_AudioPlayer.Instance.PlayHammerSound();
        if (!objectToRepair.GetComponent<Scr_BrokenObject>().broken) return;        
        actualNumber++;
        _uiHammer.RemoveBubble();
        print("Object bein repared");
        if (actualNumber >= numberToActivateMax)
        {
            Finish();
            Scr_AudioPlayer.Instance.PlaySuccessSound();
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
        _uiHammer.HideUi();

    }

    public void ShowUi()
    {
        _uiHammer.ShowUI();
    }

    void Finish()
    {
        objectToRepair.GetComponent<Scr_BrokenObject>().Interacted(gameObject);
        _uiHammer.HideUi();

    }
}
