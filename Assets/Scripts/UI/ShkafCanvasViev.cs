using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShkafCanvasViev : MonoBehaviour
{
    public UnityAction NextButtonTapEvent;

    [SerializeField] private GameObject _nextButton;

    private void Start()
    {
        _nextButton.GetComponent<Button>().onClick.AddListener(() => { NextButtonTapEvent?.Invoke(); });
    }
    public void NextButtonEnabler(bool value)
    {
        _nextButton.SetActive(value);
    }
}
