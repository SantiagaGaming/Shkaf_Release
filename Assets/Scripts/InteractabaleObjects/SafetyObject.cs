using System.Collections;
using AosSdk.Core.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;

public class SafetyObject : MonoBehaviour, IClickAble, IHoverAble
{
    public UnityAction<string> PickedEvent;
    [SerializeField] private string _name;
public bool IsClickable { get; set; } = true;
public bool IsHoverable { get; set; } = true;

public void OnHoverIn(InteractHand interactHand)
{
    GetComponent<Renderer>().material.color *= 2;
}
public void OnHoverOut(InteractHand interactHand)
{
    GetComponent<Renderer>().material.color /= 2;
}
    public void OnClicked(InteractHand interactHand)
    {
        PickedEvent?.Invoke(_name);
        gameObject.SetActive(false);
    }
    public override string ToString()
    {
        return _name;
    }

}
