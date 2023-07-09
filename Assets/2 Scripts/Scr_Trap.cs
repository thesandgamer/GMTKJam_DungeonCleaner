using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Trap : MonoBehaviour
{
    public bool armed = false;

    [SerializeField] private Sprite retractedSrpite;
    [SerializeField] private Sprite exitSrpite;
    
    [SerializeField] private List<SpriteRenderer> sprites;

    private void Awake()
    {
        if (armed)
        {
            foreach (var sprite in sprites)
            {
                sprite.sprite = retractedSrpite;
            }
        }
        else
        {
            foreach (var sprite in sprites)
            {
                sprite.sprite = exitSrpite;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!armed)
        {
            if (other.GetComponent<Scr_PlayerManager>())
            {
                Desarm();
                other.GetComponent<Scr_PlayerManager>().SlowDown();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Scr_PlayerManager>())
        {
            other.GetComponent<Scr_PlayerManager>().NormalSpeed();

        }
    }

    public void Desarm()
    {
        armed = false;
        foreach (var sprite in sprites)
        {
            sprite.sprite = exitSrpite;
        }
    }

    public void Rearm()
    {
        armed = true;
        foreach (var sprite in sprites)
        {
            sprite.sprite = retractedSrpite;
        }
    }
}
