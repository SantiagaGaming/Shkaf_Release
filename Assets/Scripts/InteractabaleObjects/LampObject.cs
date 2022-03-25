using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampObject : MonoBehaviour
{
    [SerializeField] private GameObject _color;
    private void Start()
    {
        EnableLamp(true);
    }

    public void EnableLamp(bool value)
    {
        _color.SetActive(value);
    }

}
