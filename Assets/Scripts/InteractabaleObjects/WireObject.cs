using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireObject : BaseObject
{
    [SerializeField] private GameObject _wire;
    [SerializeField] private GameObject _trunk;


    public override void StartAction()
    {
        StartCoroutine(MoveWire(true));
    }
    public override void RevertAction()
    {
        StartCoroutine(MoveWire(false));
    }
    private IEnumerator MoveWire(bool value)
    {
        if(value)
        {
            _wire.SetActive(true);
            int y = 0;
            while (y <= 43)
            {
                transform.position -= new Vector3(0, 0.001f, 0);
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
                transform.position += new Vector3(0, 0.001f, 0);
                y--;
                yield return new WaitForSeconds(0.01f);
            }
            transform.position -= new Vector3(0, 0, 0.06f);
            _wire.SetActive(false);
        }
        EndActionEvent?.Invoke();
    }
}


