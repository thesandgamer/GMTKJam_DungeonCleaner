using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Trap : MonoBehaviour
{
    public bool armed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (armed)
        {
            if (other.GetComponent<Scr_PlayerManager>())
            {
                armed = false;
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
}
