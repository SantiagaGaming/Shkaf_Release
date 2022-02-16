using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumblerObject : BaseObject
{
    [SerializeField] private GameObject _temblers;
    public override void StartAction()
    {

        StartCoroutine(RotateTumbler());
    }
    private IEnumerator RotateTumbler()
    {
        int x = 0;
        while (x <= 105)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -x);
            x++;
            yield return new WaitForSeconds(0.01f);

        }
        EndActionEvent?.Invoke();
    }
}
