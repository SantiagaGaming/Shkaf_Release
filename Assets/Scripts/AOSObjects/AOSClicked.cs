using System.Collections;
using AosSdk.Core.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;

[AosObject(name: "����� ������� �� �������")]
public class AOSClicked : AosObjectBase
{
    [AosEvent(name: "����� ������� �� ������")]
    public event AosEventHandlerWithAttribute OnPlayerClicked;

    public void PlayerClickOnObject(string name)
    {
        OnPlayerClicked?.Invoke(name);
    }
}
