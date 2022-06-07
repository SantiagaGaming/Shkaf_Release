using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class TableObject : MonoBehaviour, IClickAble, IHoverAble
{
    [SerializeField] private InventController _invent;

    public bool IsClickable { get; set; } = true;
    public bool IsHoverable { get; set; } = true;

    public void OnHoverIn(InteractHand interactHand)
    {
        GetComponent<Renderer>().material.color *= 1.5f;
    }
    public void OnHoverOut(InteractHand interactHand)
    {
        GetComponent<Renderer>().material.color /= 1.5f;
    }
    public void OnClicked(InteractHand interactHand)
    {
        _invent.ReturnItemOnTheTable();
    }
}