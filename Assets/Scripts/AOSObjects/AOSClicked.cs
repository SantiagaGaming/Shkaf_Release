using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;

[AosObject(name: "Игрок кликнул на предмет")]
public class AOSClicked : AosObjectBase
{
    [AosEvent(name: "Игрок кликнул на объект")]
    public event AosEventHandlerWithAttribute OnPlayerClicked;

    public void PlayerClickOnObject(string name)
    {
        OnPlayerClicked?.Invoke(name);
    }
}
