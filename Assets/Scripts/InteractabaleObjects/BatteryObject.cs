using AosSdk.Core.Player.Pointer;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatteryObject : BaseObject
{
    [SerializeField] private GameObject _number;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private string _numberText;
    [SerializeField] private GameObject _battery;
    [SerializeField] private GameObject _skobaBig;
    [SerializeField] private GameObject _skobaSmall;

    private InventController _inventController;
    private GameObject _currentObject;
    private void Start()
    {
        _inventController = FindObjectOfType<InventController>();
    }
    public override void StartAction()
    {
        if (_inventController.GetCurrentItem() == "SkobaSmall")
        {
            StartCoroutine(MoveObject(true, _skobaSmall));
            _currentObject = _skobaSmall;
        }
        else if (_inventController.GetCurrentItem() == "SkobaBig")
        {
            StartCoroutine(MoveObject(true, _skobaBig));
            _currentObject = _skobaBig;
        }
        else if (_inventController.GetCurrentItem() == "Battery")
        {
            StartCoroutine(MoveObject(true, _battery));
            _currentObject = _battery;
        }
        else
        { action = true;
            return;
        }
    }
    public override void RevertAction()
    {
        StartCoroutine(MoveObject(false,_currentObject));
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        base.OnHoverIn(interactHand);
        _textMesh.text = _numberText;
        _number.SetActive(true);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        base.OnHoverOut(interactHand);
        _number.SetActive(false);
    }
    private IEnumerator MoveObject(bool value, GameObject obj)
    {
        canAction = false;
        obj.SetActive(true);

        int x = 0;
        while (x <= 26)
        {
            if (value)
                obj.transform.position += new Vector3(0.001f, 0, 0);
            else
                obj.transform.position -= new Vector3(0.001f, 0, 0);
            x++;
            yield return new WaitForSeconds(0.01f);


        }
        if (!value)
            obj.SetActive(false);
        canAction = true;
    }
}
