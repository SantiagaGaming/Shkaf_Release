using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuUi : MonoBehaviour
{
    public UnityAction TrainingButtonTapEvent;
    public UnityAction PracticeButtonTapEvent;

    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private Text _loadingText;
    [SerializeField] private Button _trainingButton;
    [SerializeField] private Button _practiceButton;
    private void Start()
    {
        _trainingButton.onClick.AddListener(() => { TrainingButtonTapEvent?.Invoke(); });

        _practiceButton.onClick.AddListener(() => { PracticeButtonTapEvent?.Invoke(); });
    }
    public void ShowLoadingPanel()
    {
        _mainMenuPanel.SetActive(false);
        _loadingPanel.SetActive(true);
    }
    public void ShowLoadingText(string value)
    {
        _loadingText.text = value;
    }
}
