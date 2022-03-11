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
        _canAction = false;
        if(value)
        {
            _magnet.SetActive(true);
            int x = 0;
            while (x < 25)
            {
                _magnet.transform.position += new Vector3(0.01f, 0, 0);
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
            int x = 25;

            while (x > 0)
            {
                _magnet.transform.position -= new Vector3(0.01f, 0, 0);
                yield return new WaitForSeconds(0.02f);
                x--;
            }
            _magnet.SetActive(false);
        }
        _canAction = true;


        EndActionEvent?.Invoke();
    
    }

}
