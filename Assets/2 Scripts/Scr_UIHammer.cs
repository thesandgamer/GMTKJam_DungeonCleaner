using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_UIHammer : MonoBehaviour
{
    public List<Image> images;
    [SerializeField] private GameObject go;

    private int currentBubble = 0;

    private void Awake()
    {
        HideUi();
    }

    public void ShowUI()
    {
        go.SetActive(true);
    }

    public void HideUi()
    {
        go.SetActive(false);

        currentBubble = 0;
        foreach (var image in images)
        {
            image.enabled = true;
        }
    }
    
    public void RemoveBubble()
    {
        images[currentBubble].enabled = false;
        //images.RemoveAt(currentBubble);
        currentBubble++;
    }

}
