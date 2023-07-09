using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Take : MonoBehaviour
{
    [SerializeField] private Transform takeLocation;
    [SerializeField] private Transform releaseLocation;
    public GameObject objectInHand { get; private set; }

    public bool HaveObjectInHand()
    {
        return objectInHand != null;
    }
    
    public void TakeObject(GameObject objectToTake)
    {
        //Change Object in hand
        //Attach object to the location
        
        objectInHand = objectToTake;
        objectInHand.transform.position = takeLocation.position;
        objectToTake.transform.SetParent(takeLocation);
        
        objectToTake.GetComponent<Collider2D>().enabled = false;
        Scr_AudioPlayer.Instance.PlayTakeSound();



        print("object taken "+ objectToTake.name );
    }

    public void ReleaseObject(GameObject releaseTo)
    {
        //Check si l'objet to release existe
        //Si oui dépose sur cet objet
        //Si non dépose devant le personnage
        
        objectInHand.transform.SetParent(null);

        if (releaseTo)
        {
            objectInHand.transform.position = releaseTo.transform.position;
        }
        else
        {
            objectInHand.transform.position = releaseLocation.position;
        }
        
        objectInHand.GetComponent<Collider2D>().enabled = true;
        objectInHand = null;

    }
    

 
}
