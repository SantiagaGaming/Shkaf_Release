using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventController : MonoBehaviour
{
    [SerializeField] private GameObject[] _inventObjects;
    private string _currentItem;
    private void Start()
    {
        foreach (var item in _inventObjects)
        {
            item.GetComponent<InventObject>().SentObjectNameEvent += OnSetCurrentItem;
        }
    }
    public void ReturnItemOnTheTable()
    {
        try { GameObject tempObjj = _inventObjects.FirstOrDefault(p => p.GetComponent<InventObject>().ToString() == _currentItem); tempObjj.SetActive(true); _currentItem = ""; }
        catch { print("fail"); }
        _currentItem = "";
    }
    public void OnSetCurrentItem(string itemName)
    {
        _currentItem = itemName;
    }
    public string GetCurrentItem()
    {
        return _currentItem;
    }
}
