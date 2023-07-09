using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scr_UIStars : MonoBehaviour
{
    [Header("Stars")]
    [SerializeField]  private List<GameObject> starImagesHalf;
    [SerializeField]  private List<GameObject> starFullImages;

    [Header("Final Image")]
    [SerializeField] private Image endImage;
    [SerializeField]  private List<Sprite> EndingSrpite;

    [Header("Final Text")]
    [SerializeField] private TMP_Text  text;
    [SerializeField] private List<string>  commentarys;
    
    
    [Range(0,5)]
    public float score = 0;

    private void Start()
    {
        if (FindObjectOfType<Scr_Score>())
        {   
            score = FindObjectOfType<Scr_Score>().score;

        }
        
        Calculate();

    }

    private void Update()
    {
       //Calculate();
    }

    void Calculate()
    {
        endImage.sprite = EndingSrpite[0];


        if (score < 2.5)
        {
            endImage.sprite = EndingSrpite[0];

        }
        else
        {
            endImage.sprite = EndingSrpite[1];

        }

        if (score <= 0)
        {
            DeactivateAll();
            
        }
        else if (score >= 0.5 && score < 1)
        {
            DeactivateAll();
            starImagesHalf[0].SetActive(true);
            
        }
        else if (score >= 1 && score < 1.5)
        {
            DeactivateAll();
            starFullImages[0].SetActive(true);
            
        }
        else if (score >= 1.5 && score < 2)
        {
            DeactivateAll();
            starFullImages[0].SetActive(true);
            starImagesHalf[1].SetActive(true);
            
        }
        else if (score >= 2 && score < 2.5)
        {
            DeactivateAll();
            starFullImages[0].SetActive(true);
            starFullImages[1].SetActive(true);
            
        }
        else if (score >= 2.5 && score < 3)
        {
            DeactivateAll();
            starFullImages[0].SetActive(true);
            starFullImages[1].SetActive(true);
            starImagesHalf[2].SetActive(true);

            
        }
        else if (score >= 3 && score < 3.5)
        {
            DeactivateAll();
            starFullImages[0].SetActive(true);
            starFullImages[1].SetActive(true);
            starFullImages[2].SetActive(true);

            
        }
        else if (score >= 3.5 && score < 4)
        {
            DeactivateAll();
            starFullImages[0].SetActive(true);
            starFullImages[1].SetActive(true);
            starFullImages[2].SetActive(true);
            starImagesHalf[3].SetActive(true);

            
        }
        else if (score >= 4 && score < 4.5)
        {
            DeactivateAll();
            starFullImages[0].SetActive(true);
            starFullImages[1].SetActive(true);
            starFullImages[2].SetActive(true);
            starFullImages[3].SetActive(true);

            
        }
        else if (score >= 4.5 && score < 5)
        {
            DeactivateAll();
            starImagesHalf[0].SetActive(true);
            starFullImages[0].SetActive(true);
            starFullImages[1].SetActive(true);
            starFullImages[2].SetActive(true);
            starFullImages[3].SetActive(true);
            starImagesHalf[4].SetActive(true);

            
        }
        else if (score >= 5)
        {
            DeactivateAll();
            starImagesHalf[0].SetActive(true);
            starFullImages[0].SetActive(true);
            starFullImages[1].SetActive(true);
            starFullImages[2].SetActive(true);
            starFullImages[3].SetActive(true);
            starFullImages[4].SetActive(true);

            
        }
        
    }
    
    void DeactivateAll()
    {
        foreach (var star in starImagesHalf)
        {
            star.SetActive(false);
        }
        foreach (var star in starFullImages)
        {
            star.SetActive(false);

        }
    }
}

