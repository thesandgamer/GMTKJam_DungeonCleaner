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


    private GameObject cleaningObject;
    
    public override void Clicked(GameObject on)
    {
        
    }

    public override void Pressed(GameObject on)
    {
        cleaningObject = on;
        
        canWork = true;
    }

    public override void Released(GameObject on)
    {
        canWork = false;
        currentValue = 0;
    }

    private void Update()
    {
        if (canWork)
        {
            currentTime += Time.deltaTime;
            currentValue = curve.Evaluate(currentTime);

            if (currentValue == curve.Evaluate(curve.length))
            {
                Finish();
            }
            print("Current value:" + currentValue);
        }
    }


    void Finish()
    {
        canWork = false;
        cleaningObject.GetComponent<Scr_Dirt>().Interacted(gameObject);
    }
    
}
