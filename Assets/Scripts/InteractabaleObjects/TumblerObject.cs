using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumblerObject : BaseObject
{
    [SerializeField] private GameObject _temblers;
    public override void StartAction()
    {

        StartCoroutine(RotateTumbler(true));
    }
    public override void RevertAction()
    {
        StartCoroutine(RotateTumbler(false));
    }
    private IEnumerator RotateTumbler(bool value)
    {
        if(value)
        {
            int x = 0;
            while (x <= 105)
            {
                _temblers.transform.localRotation = Quaternion.Euler(0, 0, -x);
                x++;
                yield return new WaitForSeconds(0.01f);

            }
        }
        else
        {
            int x = 105;
            while (x >= 0)
            {
                _temblers.transform.localRotation = Quaternion.Euler(0, 0, -x);
                x--;
                yield return new WaitForSeconds(0.01f);

            }
        }

        EndActionEvent?.Invoke();
    }
}
