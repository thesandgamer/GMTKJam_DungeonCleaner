using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_UIStars : MonoBehaviour
{
    [SerializeField]  private List<Sprite> starImages;


    private void Start()
    {
        Calculate();
    }

    void Calculate()
    { 
        float score = FindObjectOfType<Scr_Score>().score;
        
    }
}
