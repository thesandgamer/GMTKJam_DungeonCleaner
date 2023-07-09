using System;
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
    private Scr_SwitchForm switchForm;
    
    private GameObject nearObject= null;
    
    public event Action ev_StartInteracting;
    public event Action ev_StopInteracting;

    private void Awake()
    {
        pc = GetComponent<S_PlayerController>();
        takeComponent = GetComponent<Scr_Take>();
        switchForm = GetComponent<Scr_SwitchForm>();
    }

    void Interact()
    {
        
    }

    private void Update()
    {   
        //Check l'objet autour 
        RaycastHit2D hitInfo = Physics2D.CircleCast(interactLocation.position, interactRadius, Vector2.right,default,layer);
        if (hitInfo)
        {
            nearObject = hitInfo.transform.gameObject;
        }
        else
        {
            nearObject = null;
        }

        if (takeComponent.objectInHand)
        {
            if (takeComponent.objectInHand.GetComponent<Scr_Hammer>())
            {
                if (nearObject)
                {
                    if (nearObject.GetComponent<Scr_BrokenObject>())
                    {
                        if (nearObject.GetComponent<Scr_BrokenObject>().broken)
                        {
                            takeComponent.objectInHand.GetComponent<Scr_Hammer>().ShowUi();
                        }
                    }
                    else
                    {
                        takeComponent.objectInHand.GetComponent<Scr_Hammer>().Reset();
                    }
                }
                else
                {
                    takeComponent.objectInHand.GetComponent<Scr_Hammer>().Reset();
                }
            }
        }

    }

    void StartInteract()
    {
        //Check
        ev_StartInteracting?.Invoke();


        
        //Interact with the near object
        if (nearObject)
        {
            //Si on peut intérgir avec l'objet
            if (nearObject.GetComponent<Scr_Interactible>())
            {
                if (takeComponent.HaveObjectInHand())
                {
                    if (takeComponent.objectInHand.GetComponent<Scr_Tool>())
                    {
                        takeComponent.objectInHand.GetComponent<Scr_Tool>().Pressed(nearObject);    //L'objet en main effectue son action
                    }
                    else
                    {
                        nearObject.GetComponent<Scr_Interactible>().Interacted(takeComponent.objectInHand);
                    }
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
                    
                    //Si état à prendre de l'objet est le même que l'état du player
                    if (nearObject.GetComponent<Scr_Takable>().canBeTakenState == state.BOTH)
                    {
                        takeComponent.TakeObject(nearObject);
                        
                    }
                    else if (nearObject.GetComponent<Scr_Takable>().canBeTakenState == switchForm.form)
                    {
                        takeComponent.TakeObject(nearObject);
                        Scr_AudioPlayer.Instance.PlayTakeSound();
                    }
                    else
                    {

                        Scr_AudioPlayer.Instance.PlayFailSound();

                    }
                }
            }

        }
        else
        {
            //Pose l'objet au sol
            if (takeComponent.HaveObjectInHand())
            {
                takeComponent.ReleaseObject(nearObject);
                Scr_AudioPlayer.Instance.PlayPutSound();
            }
        }

        nearObject = null;

    }

    void EndInteract()
    {
        
        if (takeComponent.HaveObjectInHand())
        {
            if (takeComponent.objectInHand.GetComponent<Scr_Tool>())
            {
                takeComponent.objectInHand.GetComponent<Scr_Tool>().Released(nearObject); //L'objet en main effectue son action
            }
        }
        ev_StopInteracting?.Invoke();

    }
    
    private void OnEnable()
    {
        pc.ev_Interact +=  Interact;
        pc.ev_StartInteract +=  StartInteract;
        pc.ev_StopInteract +=  EndInteract;

        switchForm.ev_ChangeForm += ctx => CheckDropItem(ctx);
    }
    private void OnDisable()
    {
        pc.ev_Interact -= Interact;
        pc.ev_StartInteract -=  StartInteract;
        pc.ev_StopInteract -=  EndInteract;
    }

    void CheckDropItem(state state)
    {
        if (!takeComponent.objectInHand) return;
        if (takeComponent.objectInHand.GetComponent<Scr_Takable>().canBeTakenState != state)
        {
            takeComponent.ReleaseObject(null);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(interactLocation.position, interactRadius);
    }


}
