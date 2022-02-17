using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : BaseObject
{

    public override void StartAction()
    {

        StartCoroutine(PushButton());
    }

    private IEnumerator PushButton()
    {
        int x = 0;
        while (x<=14)
        {
            transform.position -= new Vector3(0, 0, 0.0001f);
            yield return new WaitForSeconds(0.1f);
            x++;
        }
        while (x>=0)
        {
            transform.position += new Vector3(0, 0, 0.0001f);
            yield return new WaitForSeconds(0.1f);
            x--;

        }
        EndActionEvent?.Invoke();

    }
}

