using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampObject : MonoBehaviour
{
    [SerializeField] private Color _color;
    private void Start()
    {
        DisableLamp();
    }

    public void EnableLamp()
    {
        GetComponent<MeshRenderer>().material.color = _color;
    }
    public void DisableLamp()
    {
        GetComponent<MeshRenderer>().material.color = Color.gray;
    }
}
