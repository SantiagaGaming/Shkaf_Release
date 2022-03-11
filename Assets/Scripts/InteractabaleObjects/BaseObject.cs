using System.Collections;
using AosSdk.Core.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseObject : MonoBehaviour, IClickAble, IHoverAble
{
    [SerializeField] private string _objectName;
    public UnityAction EndActionEvent;
    public bool IsClickable { get; set; } = true;
    public bool IsHoverable { get; set; } = true;
    protected bool _action = true;

    public virtual void StartAction()
    {
       
    }
    public virtual void RevertAction()
    {

    }
    public override string ToString()
    {
        return _objectName;
    }
    public void OnClicked(InteractHand interactHand)
    {
        if(_action)
        {
            StartAction();
            _action = false;
        }
        else
        {
            RevertAction();
            _action = true;
        }
     
    }
    public void OnHoverIn(InteractHand interactHand)
    {
        GetComponent<Renderer>().material.color /= 2;
    }
    public void OnHoverOut(InteractHand interactHand)
    {
        GetComponent<Renderer>().material.color *= 2;
    }
}
