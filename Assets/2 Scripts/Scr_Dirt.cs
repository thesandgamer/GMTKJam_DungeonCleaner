using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Dirt : Scr_Interactible
{
    public override void Interacted(GameObject objectInteractedWith)
    {
        if (!objectInteractedWith) return;
        if (objectInteractedWith.GetComponent<Scr_Takable>().ObjectType == ObjectType.BROOM)
        {
            print(gameObject.name + "Have been interacted with" + (objectInteractedWith != null ? objectInteractedWith.name : "nothing" ) );
            Destroy(gameObject);
        }
    }
    
}
