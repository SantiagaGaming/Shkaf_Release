using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : BaseObject
{
    public override void StartAction()
    {
        StartCoroutine(RotateButton(true));
    }
    public override void RevertAction()
    {
        StartCoroutine(RotateButton(false));
    }
    private IEnumerator RotateButton(bool value)
    {
        canAction = false;
        if(value)
        {
            int z = -14;
            while (z <= 14)
            {
                    transform.localRotation = Quaternion.Euler(0, 0, -z);
                z++;
                yield return new WaitForSeconds(0.02f);
            }
        }
        else
        {
            int z = 14;
            while (z >= -14)
            {
                transform.localRotation = Quaternion.Euler(0, 0, -z);
                z--;
                yield return new WaitForSeconds(0.02f);
            }
        }
        canAction = true;
    }
}
