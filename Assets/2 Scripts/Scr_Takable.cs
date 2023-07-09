using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Types d'obets que le PJ peut prendre
/// </summary>
public enum ObjectType
{
    GOLD,
    FURNITURE,
    HAMMER,
    BROOM,
}

public class Scr_Takable : MonoBehaviour
{
    [SerializeField] public ObjectType ObjectType;

    public state canBeTakenState = state.SMALL;//Change to
    void Interacted(GameObject interactWith)
    {
        //En fonction du type d'objet auquel c'est 
    }
    
}
