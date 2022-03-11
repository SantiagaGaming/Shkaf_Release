using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VentObject : BaseObject
{
    public override void StartAction()
    {
     
        StartCoroutine(RotateVent(true));
    }
    public override void RevertAction()
    {
        StartCoroutine(RotateVent(false));
    }
    private IEnumerator RotateVent(bool value)
    {
        _canAction = false;
        if(value)
        {
            int x = 0;
            while (x <= 90)
            {
                transform.localRotation = Quaternion.Euler(x, 0, 0);
                x++;
                yield return new WaitForSeconds(0.01f);

            }
        }
        else
        {
            int x = 90;
            while (x >= 0)
            {
                transform.localRotation = Quaternion.Euler(x, 0, 0);
                x--;
                yield return new WaitForSeconds(0.01f);

            }
        }
        _canAction = true;

        EndActionEvent?.Invoke();
    }
}
