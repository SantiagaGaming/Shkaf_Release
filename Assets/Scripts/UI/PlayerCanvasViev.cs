using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasViev : MonoBehaviour
{
    [SerializeField] private GameObject _pickablePanel;
    [SerializeField] private Text _pickableText;
    [SerializeField] private GameObject _oscilImage;
    [SerializeField] private GameObject _handImage;
    [SerializeField] private Sprite []_oscilSprite;
    public void EnablePickablePanel(bool value)
    {
        _pickablePanel.SetActive(value);
    }
    public void ShowPickableText(string name)
    {
        _pickableText.text = name;
    }
    public void ShowOscilImage(bool value)
    {
        _oscilImage.SetActive(value);
    }
    public void ShowHandImage(bool value)
    {
        _handImage.SetActive(value);
    }
    public void ChangeOscilSprite(int number)
    {
        if (number < 0 || number > _oscilSprite.Length - 1)
            return;
        else
            _oscilImage.GetComponent<Image>().sprite = _oscilSprite[number];
    }

}
