using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PlayerCanvasViev : MonoBehaviour
{
    public UnityAction<Sprite, string> SetCurrentIconEvent;

    [SerializeField] private GameObject _zoomIcon;
    [SerializeField] private GameObject _inventIcon;
    [SerializeField] private GameObject _inventImage;
    [SerializeField] private GameObject _helpImage;
    [SerializeField] private GameObject _helpIcon;
    [SerializeField] private GameObject _currentItemImage;


    [SerializeField] private Button _batteryButton;
    [SerializeField] private Button _doorKeyButton;
    [SerializeField] private Button _circleKeyButton;
    [SerializeField] private Button _magnetKeyButton;
    [SerializeField] private Button _oscilButton;

    [SerializeField] private Text _choiseText;

    private void Start()
    {
        _batteryButton.onClick.AddListener(() => { SetCurrentIconEvent?.Invoke(_batteryButton.GetComponent<Image>().sprite, "Батарейка"); });
        _doorKeyButton.onClick.AddListener(() => { SetCurrentIconEvent?.Invoke(_doorKeyButton.GetComponent<Image>().sprite, "Ключ"); });
        _circleKeyButton.onClick.AddListener(() => { SetCurrentIconEvent?.Invoke(_circleKeyButton.GetComponent<Image>().sprite, "Круглый ключ"); });
        _magnetKeyButton.onClick.AddListener(() => { SetCurrentIconEvent?.Invoke(_magnetKeyButton.GetComponent<Image>().sprite, "Магнитный ключ"); });
        _oscilButton.onClick.AddListener(() => { SetCurrentIconEvent?.Invoke(_oscilButton.GetComponent<Image>().sprite, "Осциллограф"); });
    }

    public void ShowZoomImage(bool value)
    {
        _zoomIcon.SetActive(value);
    }
    public void ShowInventImage(bool value)
    {
        _inventIcon.SetActive(value);
        _inventImage.SetActive(value);
    }
    public void ShowHelpImage(bool value)
    {
        _helpImage.SetActive(value);
        _helpIcon.SetActive(value);
    }
    public void ShowCurrentItemImage(Sprite sprite, string text)
    {
        _currentItemImage.SetActive(true);
        _currentItemImage.GetComponent<Image>().sprite = sprite;
        _choiseText.text = "Выбран Предмет: " + text;
    }

}
