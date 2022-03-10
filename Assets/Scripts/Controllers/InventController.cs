using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InventController : MonoBehaviour
{
    public UnityAction<bool> ZoomEvent;
    public UnityAction InventEvent;
    public UnityAction HelpEvent;

    [SerializeField] private Camera _playerCamera;

    [SerializeField] private InputActionProperty _zoom;
    [SerializeField] private InputActionProperty _inventory;
    [SerializeField] private InputActionProperty _help;

    private bool _zoomed = false;
    private bool _showInvent = false;
    private bool _showHelped = false;
    private void OnEnable()
    {
        _zoom.action.performed += _ => _zoomed = true;
        _inventory.action.performed += _ => _showInvent = true;
        _help.action.performed += _ => _showHelped = true;
    }
    private void Update()
    {
       if(_zoomed == true)
        {
            if (_playerCamera.fieldOfView == 60)
            {
                _playerCamera.fieldOfView = 15;
                ZoomEvent?.Invoke(true);
            }
            else
            {
                _playerCamera.fieldOfView = 60;
                ZoomEvent?.Invoke(false);
            }
            
            _zoomed = false;
        }
       if(_showInvent ==true)
        {
            InventEvent?.Invoke();
            _showInvent = false;
        }
        if (_showHelped == true)
        {
            HelpEvent?.Invoke();
            _showHelped = false;
        }
    }

}
