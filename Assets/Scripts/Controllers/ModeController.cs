using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    [SerializeField] private GameObject _desktopPlayer;
    [SerializeField] private GameObject _zoomButton;
    private void Start()
    {
        if (!_desktopPlayer.activeSelf)
            _zoomButton.SetActive(false);
    }
}
