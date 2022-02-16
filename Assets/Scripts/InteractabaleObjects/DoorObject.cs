using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorObject : BaseObject
{
    [SerializeField] private GameObject _door;  
    public override void StartAction()
    {

        StartCoroutine(RotateDoor());
    }
    private IEnumerator RotateDoor()
    {
        int y = 0;
        while (y <= 95)
        {
            _door.transform.localRotation = Quaternion.Euler(0, y, 0);
            y++;
            yield return new WaitForSeconds(0.01f);

        }
        EndActionEvent?.Invoke();
    }
}
