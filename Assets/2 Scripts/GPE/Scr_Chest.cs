using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Chest : Scr_Interactible
{
    
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private Sprite normalSprite;



    public bool closed = true;
    public override void Interacted(GameObject objectInteractedWith)  
    {
        if (!objectInteractedWith) return;

        if (objectInteractedWith.GetComponent<Scr_Takable>().ObjectType == ObjectType.GOLD)
        {
            sprite.sprite = normalSprite;
            print(gameObject.name + "Have been interacted with" + (objectInteractedWith!=null ? objectInteractedWith.name : "nothing" ) );
            Destroy(objectInteractedWith);
            closed = false;
            Scr_AudioPlayer.Instance.PlayPutCoinsSound();
        }
    }
    
}
