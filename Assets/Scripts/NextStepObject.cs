using AosSdk.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextStepObject : MonoBehaviour, IClickAble
{
    public UnityAction StepEvent;
    private bool _canClick = false;

    public void OnClicked()
    {
        if (_canClick)
        {
            _canClick = false;
            StepEvent?.Invoke();
        }
    }
    public void AllowClick()
    {
        _canClick = true;
    }
}
