using RunnerGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIInputControl : MonoBehaviour
{
    [SerializeField] private CharacterControl control;

    private void Awake()
    {
        control = GetComponent<CharacterControl>();
    }

    public void OnJumpPressed()
    {
        control.Jump = true;
    }

    public void OnJumpReleased()
    {
        if (!control.Start)
        {
            control.Start = true;
        }
        control.Jump = false;
    }

    public void OnDashPressed()
    {
        control.Dash = true;
    }
    public void OnDashReleased()
    {
        if (!control.Start)
        {
            control.Start = true;
        }
        control.Dash = false;
    }
}
