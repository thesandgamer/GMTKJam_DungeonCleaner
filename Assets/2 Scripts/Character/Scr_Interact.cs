using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(S_PlayerController))]
[RequireComponent(typeof(Scr_Take))]
public class Scr_Interact : MonoBehaviour
{
    [SerializeField] private Transform interactLocation;
    [SerializeField] private float interactRadius = 10;
    [SerializeField] private LayerMask layer;
    
    private S_PlayerController pc;
    private Scr_Take takeComponent;
    
    private GameObject nearObject= null;

    private void Awake()
    {
        pc = GetComponent<S_PlayerController>();
        takeComponent = GetComponent<Scr_Take>();
    }

    void Interact()
    {
        
    }

    void StartInteract()
    {
        //Check
        

        //Check l'objet autour 
        RaycastHit2D hitInfo = Physics2D.CircleCast(interactLocation.position, interactRadius, Vector2.right,default,layer);
        if (hitInfo)
        {
            nearObject = hitInfo.transform.gameObject;
        }

        
        //Interact with the near object
        if (nearObject)
        {
            //Si on peut intérgir avec l'objet
            if (nearObject.GetComponent<Scr_Interactible>())
            {
                if (takeComponent.HaveObjectInHand())
                {
                    takeComponent.objectInHand.GetComponent<Scr_Tool>().Pressed(nearObject);    //L'objet en main effectue son action
                }
                else
                {
                    nearObject.GetComponent<Scr_Interactible>().Interacted(takeComponent.objectInHand);
                }
            }
            
            //Si on peut prendre l'objet.
            if (!takeComponent.HaveObjectInHand())
            {
                if (nearObject.GetComponent<Scr_Takable>())
                {
                    takeComponent.TakeObject(nearObject);
                }
            }

        }
        else
        {
            //Pose l'objet au sol
            if (takeComponent.HaveObjectInHand())
            {
                takeComponent.ReleaseObject(nearObject);
            }
        }

    }

    void EndInteract()
    {
        
        if (takeComponent.HaveObjectInHand())
        {
            takeComponent.objectInHand.GetComponent<Scr_Tool>().Released(nearObject); //L'objet en main effectue son action
        }
    }
    
    private void OnEnable()
    {
        pc.ev_Interact +=  Interact;
        pc.ev_StartInteract +=  StartInteract;
        pc.ev_StopInteract +=  EndInteract;
    }
    private void OnDisable()
    {
        pc.ev_Interact -= Interact;
        pc.ev_StartInteract -=  StartInteract;
        pc.ev_StopInteract -=  EndInteract;
    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(interactLocation.position, interactRadius);
    }


}
