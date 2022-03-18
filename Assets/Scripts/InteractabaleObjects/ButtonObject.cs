using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : BaseObject
{
    public override void StartAction()
    {

        StartCoroutine(PushButton());
    }
    public override void RevertAction()
    {

        StartCoroutine(PushButton());
    }

    private IEnumerator PushButton()
    {
        canAction = false;
        int x = 0;
        while (x<=17)
        {
            transform.position -= new Vector3(0, 0, 0.0001f);
            yield return new WaitForSeconds(0.03f);
            x++;
        }
        while (x>=0)
        {
            transform.position += new Vector3(0, 0, 0.0001f);
            yield return new WaitForSeconds(0.03f);
            x--;

        }
        canAction = true;
    }
}

