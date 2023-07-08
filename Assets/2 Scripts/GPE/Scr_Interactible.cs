using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractibleType
{
    CHEST,
    DOOR,
    TRAP,
    BROKEN_OBJECT,
}

/// <summary>
/// Classe parent pour les objets coffre, portes, pièges
/// </summary>
public class Scr_Interactible : MonoBehaviour
{
    public InteractibleType objectType;
    public virtual void Interacted(GameObject objectInteractedWith)
    {
        print(gameObject.name + "Have been interacted with" + (objectInteractedWith!=null ? objectInteractedWith.name : "nothing" ) );
    }
    
}
