using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractibleType
{
    CHEST,
    DOOR,
    TRAP,
}

/// <summary>
/// Classe parent pour les objets coffre, portes, pièges
/// </summary>
public class Scr_Interactible : MonoBehaviour
{
    public virtual void Interacted(GameObject objectInteractedWith)
    {
        print(gameObject.name + "Have been interacted with" + (objectInteractedWith!=null ? objectInteractedWith.name : "nothing" ) );
    }
    
}
