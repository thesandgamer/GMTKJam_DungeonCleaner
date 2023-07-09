using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum state
{
    SMALL,
    BIG,
    BOTH,
}
public class Scr_SwitchForm : MonoBehaviour
{
    public state form = state.SMALL;

    private S_PlayerController pc;

    [SerializeField] private SpriteRenderer handSprite;
    [SerializeField] private Animator Animator;

    public event Action<state> ev_ChangeForm;

    [SerializeField] private Sprite bigHand;
    [SerializeField] private Sprite smallHand;
    
    [SerializeField] private RuntimeAnimatorController  big;
    [SerializeField] private RuntimeAnimatorController  small;

    [SerializeField] private Sprite UItoBig;
    [SerializeField] private Sprite UItoSmall;
    [SerializeField] private Image UISwitch;

    private void Awake()
    {
        pc = GetComponent<S_PlayerController>();
    }


    public void ChangeForm()
    {
        Scr_AudioPlayer.Instance.PlayChangeFormSound();
        if (form == state.SMALL)
        {
            form = state.BIG;
            handSprite.sprite = bigHand;
            Animator.runtimeAnimatorController = big;
            UISwitch.sprite = UItoBig;
            Debug.Log("BIG FORM");
        }
        else
        {
            form = state.SMALL;
            handSprite.sprite = smallHand;
            Animator.runtimeAnimatorController = small;
            UISwitch.sprite = UItoSmall;
            Debug.Log("SMALL FORM");


        }
        ev_ChangeForm?.Invoke(form);

    }

    private void OnEnable()
    {
        pc.ev_SwitchForm += ChangeForm;
    }

    private void OnDisable()
    {
        pc.ev_SwitchForm -= ChangeForm;

    }
}
