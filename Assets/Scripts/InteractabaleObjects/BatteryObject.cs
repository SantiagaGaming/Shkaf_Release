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
    public override void StartAction()
    {

        StartCoroutine(Move(true));
    }
    public override void RevertAction()
    {
        StartCoroutine(Move(false));
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
    private IEnumerator Move(bool value)
    {

            yield return new WaitForSeconds(0.01f);
 
  
        canAction = true;
    }
}
