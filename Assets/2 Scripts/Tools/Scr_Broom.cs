using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scr_Broom : Scr_Tool
{
    private float currentTime = 0;
    private float currentValue = 0;
    [SerializeField] private float maxValue = 10;
    private float incrementation = 1;

    [SerializeField] private AnimationCurve curve;

    [SerializeField] private GameObject LifeBar;
     private Scr_BarFiller filler;

     private Scr_PlayerManager playerManager;


    private GameObject cleaningObject;

    private void Start()
    {
        HideLifeBar();
        filler = GetComponent<Scr_BarFiller>();
        filler.SetMaxValue((float)curve.keys[curve.length-1].time);
        
        playerManager = FindObjectOfType<Scr_PlayerManager>();
    }

    public override void Clicked(GameObject on)
    {
        
    }

    public override void Pressed(GameObject on)
    {
        if (on.GetComponent<Scr_Interactible>())
        {
            if (on.GetComponent<Scr_Interactible>().objectType == InteractibleType.BLOOD)
            {
                cleaningObject = on;
                LifeBar.SetActive(true);

                canWork = true;
        
                playerManager.Immobilise();

                Scr_AudioPlayer.Instance.PlayCleanSound();
            }

        }
    
    }

    public override void Released(GameObject on)
    {

        Reset();
        
        if (LifeBar.activeSelf)
        {
            Invoke("HideLifeBar",1);
        }
        playerManager.Remobilise();

    }

    private void Reset()
    {
        canWork = false;
        currentValue = 0;
        currentTime = 0;
        
        filler.SetValue(0);
    }

    private void HideLifeBar()
    {
        LifeBar.SetActive(false);
    }

    private void Update()
    {
        if (canWork)
        {
            currentTime += Time.deltaTime;
            currentValue = curve.Evaluate(currentTime);

            if (currentValue == curve.keys[curve.length-1].value)
            {
                Finish();
            }
            else
            {
                filler.SetValue(currentTime);
            }
//            print("Current value:" + currentValue);
        }
    }


    void Finish()
    {
        print("Cleaning finish");
        Reset();

        
        cleaningObject.GetComponent<Scr_Dirt>().Interacted(gameObject);
        
        Invoke("HideLifeBar",.1f);

    }
    
}
