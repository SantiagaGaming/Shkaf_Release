using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDoorKeyObject : BaseObject
{
    [SerializeField] private GameObject _upDoorKey;

    public override void StartAction()
    {

        StartCoroutine(MoveKey(true));
    }
    public override void RevertAction()
    {
        StartCoroutine(MoveKey(false));
    }
    private IEnumerator MoveKey(bool value)
    {
        _upDoorKey.SetActive(true);
        if(value)
        {
            int z = 0;
            while (z <= 7)
            {
                _upDoorKey.transform.position += new Vector3(0.008f, 0, 0);
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
       
            while (z > 0)
            {
                _upDoorKey.transform.position -= new Vector3(0.008f, 0,0 );
                z--;
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            int z = 0;
            while (z <= 7)
            {
                _upDoorKey.transform.position += new Vector3(0.008f, 0,0 );
                z++;
                yield return new WaitForSeconds(0.05f);
            }

            int xRot = 90;
            while (xRot > 0)
            {
                _upDoorKey.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
                xRot--;
                yield return new WaitForSeconds(0.01f);
            }
            
            while (z > 0)
            {
                _upDoorKey.transform.position -= new Vector3(0.008f, 0,0 );
                z--;
                yield return new WaitForSeconds(0.05f);

            }
        }
        _upDoorKey.SetActive(false);

        EndActionEvent?.Invoke();
    }
}


