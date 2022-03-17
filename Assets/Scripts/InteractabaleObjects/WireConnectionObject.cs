using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireConnectionObject : BaseObject
{
    [SerializeField] private Transform _redWirePos;
    [SerializeField] private Transform _blackWirePos;

    private WireController _wireController;
    private void Start()
    {
        _wireController = FindObjectOfType<WireController>();
    }
    public override void StartAction()
    {
        _wireController.SetWiresPositions(_blackWirePos, _redWirePos);
        _wireController.ChangeWiresPositions();
    }
    public override void RevertAction()
    {
        _wireController.ChangeWiresPositions();
    }

}
