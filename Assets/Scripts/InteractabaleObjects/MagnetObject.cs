using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetObject : BaseObject
{
    [SerializeField] private GameObject _magnetRod;
    [SerializeField] private GameObject _magnet;
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
        canAction = false;
        if(value)
        {
            _magnet.SetActive(true);
            int x = 0;
            while (x < 25)
            {
                _magnet.transform.localPosition += new Vector3(0.01f, 0, 0);
                yield return new WaitForSeconds(0.03f);
                x++;
            }
            while (x < 32)
            {
                _magnetRod.transform.position -= new Vector3(0.0005f, 0, 0);
                yield return new WaitForSeconds(0.03f);
                x++;
            }
        }
        else
        {
            int x = 32;
            while (x > 25)
            {
                _magnetRod.transform.position += new Vector3(0.0005f, 0, 0);
                x--;
            }

            while (x > 0)
            {
                _magnet.transform.localPosition -= new Vector3(0.01f, 0, 0);
                yield return new WaitForSeconds(0.03f);
                x--;
            }
            _magnet.SetActive(false);
        }
        canAction = true;    
    }

}
