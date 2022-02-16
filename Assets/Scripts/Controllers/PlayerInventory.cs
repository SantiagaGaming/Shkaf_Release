using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PlayerInventory : MonoBehaviour
{
    private List<Item> _items;
    private void Start()
    {
        _items = new List<Item>();
    }
    public void AddItem(Item item)
    {
        _items.Add(item);
    }
    public bool GetItemName(string itemName)
    {
        if (_items.FirstOrDefault(item => item.GetItemName() == itemName))
        {
            return true;
        }
        else return false;
    }

}
