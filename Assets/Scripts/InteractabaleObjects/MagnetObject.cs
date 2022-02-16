using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetObject : BaseObject
{
    public GameObject _magnetRod;
    public override void StartAction()
    {
        StartCoroutine(MoveMagnet());
    }
    private IEnumerator MoveMagnet()
    {
        int x = 0;
        while (x<25)
        {
            transform.position += new Vector3(0.01f, 0, 0);
            yield return new WaitForSeconds(0.02f);
            x++;
        }
        while(x<32)
        {
            _magnetRod.transform.position -= new Vector3(0.001f, 0, 0);
            yield return new WaitForSeconds(0.02f);
            x++;
        }
        EndActionEvent?.Invoke();
    
    }

}
