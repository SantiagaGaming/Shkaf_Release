using System.Collections;
using System.Collections.Generic;
using AosSdk.Core.Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour, IHoverAble, IClickAble
{
    public UnityAction<string> SetHoverNameEvent;
    public UnityAction<Item> AddItemEvent;
    public UnityAction WrongItemEvent;

    [SerializeField] private string _uiName;
    [SerializeField] private string _name;
    [SerializeField] private int _sceneOfItem;

    public void OnClicked()
    {
        if (_sceneOfItem == FindObjectOfType<ScenarioStepsController>().GetScenarioStepIndex())
        {
            gameObject.SetActive(false);
            AddItemEvent?.Invoke(this);
        
        }
        else WrongItemEvent?.Invoke();
    }

    public void OnHoverIn()
    {
        SetHoverNameEvent?.Invoke(_uiName);
    }

    public void OnHoverOut()
    {
        SetHoverNameEvent?.Invoke("");
    }
    public string GetItemName()
    {
        return _name;
    }
}
