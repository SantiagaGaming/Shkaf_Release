using System.Collections;
using AosSdk.Core.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseObject : MonoBehaviour, IClickAble, IHoverAble
{
    public bool IsClickable { get; set; } = true;
    public bool IsHoverable { get; set; } = true;
    protected bool action = true;
    protected bool canAction = true;

    public virtual void StartAction()
    {
       
    }
    public virtual void RevertAction()
    {

    }
    public void OnClicked(InteractHand interactHand)
    {
        if(canAction)
        {
            if (action)
            {
                StartAction();
                action = false;
            }
            else
            {
                RevertAction();
                action = true;
            }
        }

     
    }
    public void OnHoverIn(InteractHand interactHand)
    {
        GetComponent<Renderer>().material.color *= 2;
    }
    public void OnHoverOut(InteractHand interactHand)
    {
        GetComponent<Renderer>().material.color /= 2;
    }
}
