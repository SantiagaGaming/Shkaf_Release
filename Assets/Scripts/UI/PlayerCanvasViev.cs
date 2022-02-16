using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasViev : MonoBehaviour
{
    [SerializeField] private GameObject _pickablePanel;
    [SerializeField] private Text _pickableText;
    public void EnablePickablePanel(bool value)
    {
        _pickablePanel.SetActive(value);
    }
    public void ShowPickableText(string name)
    {
        _pickableText.text = name;
    }

}
