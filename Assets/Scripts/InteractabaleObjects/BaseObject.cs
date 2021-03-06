using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
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
    protected AOSClicked _aosClicked;
    public virtual void StartAction()
    {
       
    }
    public virtual void RevertAction()
    {

    }
    public void OnClicked(InteractHand interactHand)
    {
        _aosClicked = FindObjectOfType<AOSClicked>();
        _aosClicked.PlayerClickOnObject(gameObject.name);
        if(canAction)
        {
            if (action)
            {
                action = false;
                StartAction();
           
            }
            else
            {
                action = true;
                RevertAction();            }
        }

     
    }
    public virtual void OnHoverIn(InteractHand interactHand)
    {
        if (GetComponent<Renderer>())
            GetComponent<Renderer>().material.color *= 1.5f;
        else if (GetComponentInChildren<Renderer>())
            GetComponentInChildren<Renderer>().material.color *= 1.5f;
        else if (GetComponentInParent<Renderer>())
            GetComponentInParent<Renderer>().material.color *= 1.5f;
        else return;

    }
    public virtual void OnHoverOut(InteractHand interactHand)
    {
        if (GetComponent<Renderer>())
            GetComponent<Renderer>().material.color /= 1.5f;
        else if (GetComponentInChildren<Renderer>())
            GetComponentInChildren<Renderer>().material.color /= 1.5f;
        else if (GetComponentInParent<Renderer>())
            GetComponentInParent<Renderer>().material.color /= 1.5f;
        else return;
    }
}
