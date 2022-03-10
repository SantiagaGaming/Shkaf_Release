using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvasController : MonoBehaviour
{
    [SerializeField] private PlayerCanvasViev _viev;

    [SerializeField] private InventController _Invent;
    [SerializeField] private CursorController _cursor;

    private bool _invent = false;
    private bool _help = false;

    private void OnEnable()
    {
        _Invent.ZoomEvent += OnZoomImageEnabler;
        _Invent.InventEvent += OnInventShowEnabler;
        _Invent.HelpEvent += OnHelpShowEnabler;
        _viev.SetCurrentIconEvent += OnSetCurrentImage;
    }
    private void OnDisable()
    {
        _Invent.ZoomEvent -= OnZoomImageEnabler;
        _Invent.InventEvent -= OnInventShowEnabler;
        _Invent.HelpEvent -= OnHelpShowEnabler;
        _viev.SetCurrentIconEvent -= OnSetCurrentImage;
    }

    private void OnZoomImageEnabler(bool value)
    {
        _viev.ShowZoomImage(value);
    }
    private void OnInventShowEnabler()
    {
        if(_invent)
        {
            _invent = false;
            _cursor.SwitchMouse(_invent);
        }
        else
        {
            _invent = true;
            _cursor.SwitchMouse(_invent);
        }
        _viev.ShowInventImage(_invent);
    }


    private void OnHelpShowEnabler()
    {
        if (_help)
        {
            _help = false;
        }
        else
        {
           _help = true;
        }
        _viev.ShowHelpImage(_help);
    }
    private void OnSetCurrentImage(Sprite sprite, string text)
    {
        _viev.ShowCurrentItemImage(sprite, text);
    }
}

