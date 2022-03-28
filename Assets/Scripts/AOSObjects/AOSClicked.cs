using System.Collections;
using AosSdk.Core.Interfaces;
using AosSdk.Core.Utils;
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
