using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Chest : Scr_Interactible
{
    private bool closed = true;
    public override void Interacted(GameObject objectInteractedWith)  
    {
        if (!objectInteractedWith) return;

        if (objectInteractedWith.GetComponent<Scr_Takable>().ObjectType == ObjectType.GOLD)
        {
            print(gameObject.name + "Have been interacted with" + (objectInteractedWith!=null ? objectInteractedWith.name : "nothing" ) );
            Destroy(objectInteractedWith);
            closed = false;
        }
    }
    
}
