using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetObject : BaseObject
{
    public GameObject _magnetRod;
    public override void StartAction()
    {
        StartCoroutine(MoveMagnet(true));
    }
    public override void RevertAction()
    {
        StartCoroutine(MoveMagnet(false));
    }
    private IEnumerator MoveMagnet(bool value)
    {
        if(value)
        {
            int x = 0;
            while (x < 25)
            {
                transform.position += new Vector3(0.01f, 0, 0);
                yield return new WaitForSeconds(0.02f);
                x++;
            }
            while (x < 32)
            {
                _magnetRod.transform.position -= new Vector3(0.001f, 0, 0);
                yield return new WaitForSeconds(0.02f);
                x++;
            }
        }
        else
        {
            int x = 32;

            while (x > 0)
            {
                transform.position -= new Vector3(0.01f, 0, 0);
                yield return new WaitForSeconds(0.02f);
                x--;
            }
        }

        EndActionEvent?.Invoke();
    
    }

}
