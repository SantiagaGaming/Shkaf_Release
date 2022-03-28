using System.Collections;
using AosSdk.Core.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;


[AosObject(name: "Зеленая Лампа малой двери")]
public class LampGreen : AosObjectBase
{
    [SerializeField] private LampObject _lamp;

    [AosAction(name: "Включить лампочку")]
    public void EnableLamp()
    {
        _lamp.EnableLamp();
    }

    [AosAction(name: "Выключить лампочку")]
    public void DisableLamp()
    {
        _lamp.DisableLamp();
    }
}

