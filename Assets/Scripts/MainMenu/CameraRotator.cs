using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
     [SerializeField] GameObject _target;

    void Update()
    {
        transform.RotateAround(_target.transform.position, Vector3.up, 5 * Time.deltaTime);
    }
}
