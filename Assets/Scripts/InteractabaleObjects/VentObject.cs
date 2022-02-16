using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VentObject : BaseObject
{
    public override void StartAction()
    {
     
        StartCoroutine(RotateVent());
    }
    private IEnumerator RotateVent()
    {
        int x = 0;
        while (x <= 90)
        {
            transform.localRotation = Quaternion.Euler(x, 0, 0);
            x++;
            yield return new WaitForSeconds(0.01f);
         
        }
        EndActionEvent?.Invoke();
    }
}
