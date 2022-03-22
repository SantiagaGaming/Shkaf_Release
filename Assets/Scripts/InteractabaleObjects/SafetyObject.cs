using System.Collections;
using AosSdk.Core.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;

public class SafetyObject : BaseObject
{
    public UnityAction<bool,string> PickedEvent;
    [SerializeField] private string _name;
    [SerializeField] private GameObject _safetyObject;

    public override void StartAction()
    {
        PickedEvent?.Invoke(true, _name);
        _safetyObject.SetActive(false);
    }
    public override void RevertAction()
    {
        PickedEvent?.Invoke(false, _name);
        _safetyObject.SetActive(true);
    }
    public override string ToString()
    {
        return _name;
    }
}
