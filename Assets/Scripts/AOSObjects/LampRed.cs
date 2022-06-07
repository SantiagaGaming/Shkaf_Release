using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;


[AosObject(name: "������� ����� ����� �����")]
public class LampRed : AosObjectBase
{
    [SerializeField] private LampObject _lamp;

    [AosAction(name: "�������� ��������")]
    public void EnableLamp()
    {
        _lamp.EnableLamp();
    }

    [AosAction(name: "��������� ��������")]
    public void DisableLamp()
    {
        _lamp.DisableLamp();
    }
}
