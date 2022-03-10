using AosSdk.Core.Utils;
using UnityEngine;
using AosSdk.Core.Player;
using AosSdk.Core.Interfaces;


public class CursorController : MonoBehaviour
{
    [SerializeField] private GameObject _playerCrossHair;

    public void SwitchMouse(bool value)
    {
        _playerCrossHair.SetActive(!value);
        Player.Instance.EnableRayCaster(!value);
        Player.Instance.CanMove = !value;
        if(value)
            Cursor.lockState = CursorLockMode.None;
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
         
        Cursor.visible = value;
    }
}
       

