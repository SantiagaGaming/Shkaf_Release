using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventController : MonoBehaviour
{
    [SerializeField] private GameObject[] _inventObjects;
    [SerializeField] private CurrentItem _currentItem;
    [SerializeField] private GameObject []_safetyIcons;
    [SerializeField] private GameObject[] _safetyObjects;
    private string _currentItemText;
    private void Start()
    {
        foreach (var item in _inventObjects)
        {
            item.GetComponent<InventObject>().SentObjectNameEvent += OnSetCurrentItem;
        }
        _currentItemText = "Null";

        foreach (var item in _safetyObjects)
        {
            item.GetComponent<SafetyObject>().PickedEvent += OnShowSafetyIcon;
        }
    }
    public void ReturnItemOnTheTable()
    {
        try { GameObject tempObj = _inventObjects.FirstOrDefault(p => p.GetComponent<InventObject>().ToString() == _currentItemText); tempObj.SetActive(true); _currentItemText = ""; }
        catch { print("fail"); }
        _currentItemText = "Null";
        SetCurrentItemSprite(_currentItemText);
    }
    public void OnSetCurrentItem(string itemName)
    {
        _currentItemText = itemName;
        SetCurrentItemSprite(_currentItemText);
    }
    public string GetCurrentItem()
    {
        return _currentItemText;
    }
    private void SetCurrentItemSprite(string name)
    {
        _currentItem.ShowCurrentItem(name);
    }
    private void OnShowSafetyIcon(bool value, string name)
    {
        try { GameObject tempObj = _safetyIcons.FirstOrDefault(p => p.name == name); tempObj.SetActive(value); }
        catch { print("fail"); }
    }
}
