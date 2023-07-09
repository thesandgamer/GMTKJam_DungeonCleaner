using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Door : Scr_Interactible
{

    public bool isOpen = true;

     [SerializeField] private Transform closedLocation;
     [SerializeField] private Transform openLocation;

     [SerializeField] private GameObject Door;


     private void Awake()
     {
         if (isOpen)
         {
             Door.GetComponent<BoxCollider2D>().enabled = false;
         }
     }

     public override void Interacted(GameObject objectInteractedWith)  
    {
        if (isOpen)
        {
            Debug.Log("Open Door");
            Door.transform.position = closedLocation.position;
            //LeanTween.move(Door, closedLocation,1).setEase(LeanTweenType.easeInOutBack);
            Door.GetComponent<BoxCollider2D>().enabled = true;
            isOpen = false;


        }
        else
        {
            Debug.Log("Close Door");
            Door.transform.position = openLocation.position;

            //LeanTween.move(Door, closedLocation,1).setEase(LeanTweenType.easeInOutBack);
            Door.GetComponent<BoxCollider2D>().enabled = false;
            isOpen = true;

        }
    }
}
