using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _shkavCanvasViev;
    [SerializeField] private Camera _flyCamera;
    public void SwitchCamera(bool value)
    {
        _player.SetActive(!value);
        _shkavCanvasViev.SetActive(value);
        _flyCamera.enabled = value;
        _flyCamera.GetComponent<AudioListener>().enabled = value;
        Cursor.visible = value;
        if (value)
            Cursor.lockState = CursorLockMode.None;
        else  Cursor.lockState = CursorLockMode.Locked; 
    }
}
