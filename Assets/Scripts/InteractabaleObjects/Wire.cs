using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] private GameObject _wire;
    [SerializeField] private GameObject _trunk;

    private Transform _newWirePosition;

    private bool _change = true;

    public void StartAction()
    {
        if(_change)
        {
        transform.position = _newWirePosition.position;
        transform.rotation = _newWirePosition.rotation;

            StartCoroutine(MoveWire(true));
        }
    }
    public void RevertAction()
    {
        if(_change)
        StartCoroutine(MoveWire(false));
    }
    private IEnumerator MoveWire(bool value)
    {
        transform.parent = null;
        _change = false;
        if (value)
        {
            _wire.SetActive(true);
            int y = 0;
            while (y <= 43)
            {
                transform.localPosition -= new Vector3(0, 0.001f, 0);
                y++;
                yield return new WaitForSeconds(0.01f);

            }
            int xRot = -17;
            while (xRot < -3)
            {
                _trunk.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
                xRot++;
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            int xRot = -3;
            while (xRot > -17)
            {
                _trunk.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
                xRot--;
                yield return new WaitForSeconds(0.05f);
            }
            int y = 43;
            while (y >= 0)
            {
                transform.localPosition += new Vector3(0, 0.001f, 0);
                y--;
                yield return new WaitForSeconds(0.01f);
            }
            transform.position -= new Vector3(0, 0, 0.06f);
            _wire.SetActive(false);
        }
        transform.SetParent(_newWirePosition);
        _change = true;
    }
    public void SetNewWirePosition(Transform newpos)
    {
        _newWirePosition = newpos;
    }
}


