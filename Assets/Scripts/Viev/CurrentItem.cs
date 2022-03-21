using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CurrentItem : MonoBehaviour
{
    [SerializeField] private Sprite[] _currentItemSprites;

    public void ShowCurrentItem(string name)
    {
    Sprite sprite = _currentItemSprites.FirstOrDefault(p => p.name == name);
        GetComponent<Image>().sprite = sprite;
    }
}
