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
    

    private void Awake()
    {
        pc = GetComponent<S_PlayerController>();
    }


    public void ChangeForm()
    {
        if (form == state.SMALL)
        {
            form = state.BIG;
            _sprite.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            Debug.Log("BIG FORM");
        }
        else
        {
            form = state.SMALL;
            _sprite.transform.localScale = new Vector3(1f, 1f, 1f);
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
