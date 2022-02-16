using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireObject : BaseObject
{
    [SerializeField] private GameObject _wire;
    [SerializeField] private GameObject _trunk;


    public override void StartAction()
    {

        StartCoroutine(MoveWire());
    }
    private IEnumerator MoveWire()
    {
        _wire.SetActive(true);
        int z = 0;
        while (z <= 43)
        {
            transform.position -= new Vector3(0, 0.001f, 0);
            z++;
            yield return new WaitForSeconds(0.01f);

        }
        int xRot = -17;
        while (xRot < -3)
        {
           _trunk.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
            xRot++;
            yield return new WaitForSeconds(0.05f);
        }

        EndActionEvent?.Invoke();
    }
}


