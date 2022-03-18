using System.Collections;
using AosSdk.Core.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class ZoomButton : BaseButtton
{

    [SerializeField] private Zoom _zoom;
    public override void OnClicked(InteractHand interactHand)
    {
        _zoom.ZoomCamera();
    }
}

