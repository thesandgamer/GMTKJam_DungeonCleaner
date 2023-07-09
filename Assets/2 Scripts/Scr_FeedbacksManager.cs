using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_FeedbacksManager : MonoBehaviour
{
    private Scr_Tweener_Feedbacks tweener;


    [Header("   Frog")] 
    [SerializeField] private GameObject fx_ToadCollected_Prefab;
    [Header("   Toad")] 
    [SerializeField] private GameObject fx_FrogEjected_Prefab;
    [SerializeField] private GameObject fx_ToadBlock_Prefab;

    private void OnEnable()
    {

    }

    private void Awake()
    {
        tweener = GetComponent<Scr_Tweener_Feedbacks>();
    }

    public void PopUpUi(GameObject panel)
    {
        panel.transform.localScale = Vector3.zero;
        tweener.PopUp(panel,Vector3.one, 0.5f,0,LeanTweenType.easeOutBounce);
    }
    
    public void DePopUpUi(GameObject panel)
    {
        panel.transform.localScale = Vector3.one;
        tweener.PopUp(panel,Vector3.zero, 0.5f,0,LeanTweenType.easeOutBounce);
    }
    
    
    public void PopUpTimer(GameObject panel)
    {
        panel.transform.localScale = Vector3.zero;
        tweener.PopUp(panel,Vector3.one, 0.5f,0,LeanTweenType.easeOutBack);
    }
    
    public void DePopGo(GameObject panel)
    {
       // panel.transform.localScale = Vector3.one;
        tweener.PopUp(panel,Vector3.zero, 0.5f,0,LeanTweenType.easeInQuad);
    }


    public void TimerNearEndFb(GameObject panel)
    {
        tweener.UiRotateLeftRight(panel,new Vector3(0,0,5),0.5f,LeanTweenType.easeInOutBack);
        tweener.UiSizeUpAndDown(panel, new Vector3(1.1f, 1.1f, 1.1f), 0.2f, LeanTweenType.easeInOutBack);
        tweener.UiChangeColor(panel.transform.GetChild(0).gameObject,Color.red, 0.1f,LeanTweenType.linear);
        tweener.UiChangeColor(panel.transform.GetChild(1).gameObject,Color.red, 0.1f,LeanTweenType.linear);
        tweener.UiChangeColor(panel.transform.GetChild(2).gameObject,Color.red, 0.1f,LeanTweenType.linear);
    }
    
    
}
