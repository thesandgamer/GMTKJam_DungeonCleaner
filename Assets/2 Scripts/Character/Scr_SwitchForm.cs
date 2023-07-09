using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    [SerializeField] private SpriteRenderer _sprite;

    public event Action<state> ev_ChangeForm;

    [SerializeField] private Sprite bigMan;
    [SerializeField] private Sprite smallMan;
    

    private void Awake()
    {
        pc = GetComponent<S_PlayerController>();
    }


    public void ChangeForm()
    {
        if (form == state.SMALL)
        {
            form = state.BIG;
            _sprite.sprite = bigMan;
            Debug.Log("BIG FORM");
        }
        else
        {
            form = state.SMALL;
            _sprite.sprite = smallMan;
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
