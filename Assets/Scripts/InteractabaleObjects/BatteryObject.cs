using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryObject : BaseObject
{
    [SerializeField] private GameObject _battery;
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
        _battery.SetActive(true);
    
        int x = 0;
        while (x <= 26)
        {
     if(value)
            transform.position += new Vector3(0.001f,0 , 0);
     else
                transform.position -= new Vector3(0.001f, 0, 0);
            x++;
            yield return new WaitForSeconds(0.01f);
 
  
        }
        EndActionEvent?.Invoke();
        if (!value)
            _battery.SetActive(false);
    }
}
