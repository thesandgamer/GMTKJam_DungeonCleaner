using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_BrokenObject : Scr_Interactible
{
    public bool broken = true;
    
    public override void Interacted(GameObject objectInteractedWith)
    {
        if (!objectInteractedWith) return;
        if (objectInteractedWith.GetComponent<Scr_Takable>().ObjectType == ObjectType.HAMMER)
        {
            print(gameObject.name + "Have been interacted with" + (objectInteractedWith != null ? objectInteractedWith.name : "nothing" ) );
            broken = false;
        }
    }
}
