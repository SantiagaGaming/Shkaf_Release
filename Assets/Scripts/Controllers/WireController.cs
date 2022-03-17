using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireController : MonoBehaviour
{
    [SerializeField] private Wire _blackWire;
    [SerializeField] private Wire _redWire;
    private Transform _blackWirePos;
    private Transform _redWirePos;
    private bool _action = true;
    private bool _canAction = true;

    public void ChangeWiresPositions()
    {
        if(_canAction)
        {
            _canAction = false;
            StartCoroutine(ChangePos());
        }
 
    }
    private IEnumerator ChangePos()
    {
        if (_action)
        {
            _action = false;
            _blackWire.SetNewWirePosition(_blackWirePos);
            _redWire.SetNewWirePosition(_redWirePos);
            _blackWire.StartAction();
            yield return new WaitForSeconds(1f);
            _redWire.StartAction();
            yield return new WaitForSeconds(1f);
   
        }
        else
        {
            _action = true;
            _blackWire.RevertAction();
            yield return new WaitForSeconds(1f);
            _redWire.RevertAction();
            yield return new WaitForSeconds(1f);
        }
        _canAction = true;
    }
    public void SetWiresPositions(Transform blackPos, Transform redPos)
    {
        _blackWirePos = blackPos;
        _redWirePos = redPos;
    }

}
