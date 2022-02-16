using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDoorKeyObject : BaseObject
{
    [SerializeField] private GameObject _upDoorKey;

    public override void StartAction()
    {

        StartCoroutine(MoveKey());
    }
    private IEnumerator MoveKey()
    {
        _upDoorKey.SetActive(true);
        int z = 0;
        while (z <= 7)
        {
            transform.position += new Vector3(0,0,- 0.008f);
            z++;
            yield return new WaitForSeconds(0.05f);

        }
        int xRot = 0;
        while (xRot < 90)
        {
            _upDoorKey.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
            xRot++;
            yield return new WaitForSeconds(0.01f);
        }
        _upDoorKey.SetActive(false);

        EndActionEvent?.Invoke();
    }
}


