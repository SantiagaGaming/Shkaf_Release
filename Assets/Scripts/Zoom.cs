using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Zoom: MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    public void ZoomCamera()
    {
        if (_playerCamera.fieldOfView == 60)
        {
            _playerCamera.fieldOfView = 15;
        }
        else
        {
            ResetZoomCamera();
        }
    }
    public void ResetZoomCamera()
    {
        _playerCamera.fieldOfView = 60;
    }
}
