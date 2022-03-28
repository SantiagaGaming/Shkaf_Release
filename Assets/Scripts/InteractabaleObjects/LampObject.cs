using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampObject : MonoBehaviour
{
    [SerializeField] private GameObject _color;

    public void EnableLamp()
    {
        _color.SetActive(true);
    }
    public void DisableLamp()
    {
        _color.SetActive(false);
    }

}
