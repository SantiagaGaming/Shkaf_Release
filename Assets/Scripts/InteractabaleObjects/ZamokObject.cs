using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZamokObject : BaseObject
{
    [SerializeField] private GameObject _smallHandle;
    [SerializeField] private GameObject _bigHandle;
    [SerializeField] private GameObject _zamokBack;
    [SerializeField] private GameObject _key;

    public override void StartAction()
    {

        StartCoroutine(OpenLocker());
    }
    private IEnumerator OpenLocker()
    {
        int smallX = 0;
        while (smallX <= 60)
        {
            _smallHandle.transform.localRotation = Quaternion.Euler(-smallX, 0, 0);
            smallX++;
            yield return new WaitForSeconds(0.01f);

        }
        int keyX = 0;
        while (keyX < 80)
        {
            _key.transform.position += new Vector3(0.001f, 0, 0);
            keyX++;
            yield return new WaitForSeconds(0.01f);
        }
        int keyXRot = -90;
        while (keyXRot > -180)
        {
            _key.transform.localRotation = Quaternion.Euler(keyXRot, 0, 0);
            keyXRot--;
            yield return new WaitForSeconds(0.01f);
        }
        int bigZ = 0;
        while (bigZ<30)
        {
            _bigHandle.transform.localRotation = Quaternion.Euler(0,0, -bigZ);
            bigZ++;
            yield return new WaitForSeconds(0.01f);
        }

        int bigX = 0;
        while (bigX<35)
        {
            _bigHandle.transform.localRotation = Quaternion.Euler(-bigX, 0, -bigZ);
            bigX++;
            yield return new WaitForSeconds(0.01f);

        }
        _zamokBack.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        EndActionEvent?.Invoke();
    }
}

