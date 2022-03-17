using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryObject : BaseObject
{
    [SerializeField] private GameObject _battery;
    [SerializeField] private GameObject _batteryObj;
    public override void StartAction()
    {

        StartCoroutine(Move(true));
    }
    public override void RevertAction()
    {
        StartCoroutine(Move(false));
    }
    private IEnumerator Move(bool value)
    {
        _batteryObj.SetActive(true);
        _canAction = false;
        int x = 0;
        while (x <= 26)
        {
     if(value)
                _battery.transform.position += new Vector3(0.001f,0 , 0);
     else
                _battery.transform.position -= new Vector3(0.001f, 0, 0);
            x++;
            yield return new WaitForSeconds(0.01f);
 
  
        }
        if (!value)
            _batteryObj.SetActive(false);
        _canAction = true;
    }
}
