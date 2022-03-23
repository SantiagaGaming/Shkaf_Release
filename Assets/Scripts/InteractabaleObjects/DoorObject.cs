using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorObject : BaseObject
{
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _bigProvod;
    [SerializeField] private GameObject _midProvod;
    [SerializeField] private GameObject _smallProvod;
    [SerializeField] private bool _smallDoor;
    public override void StartAction()
    {

        StartCoroutine(RotateDoor(true));
    }
    public override void RevertAction()
    {
        StartCoroutine(RotateDoor(false));
    }
    private IEnumerator RotateDoor(bool value)
    {
        canAction = false;
        if (value)
        {
            int y = 0;
            while (y <= 90)
            {
                _door.transform.localRotation = Quaternion.Euler(0, y, 0);
                if(_bigProvod!=null)
                _bigProvod.transform.localRotation = Quaternion.Euler(0, y-90, 0);
                if (_midProvod != null)
                    _midProvod.transform.localRotation = Quaternion.Euler(0, y, 0);
                if (_smallProvod != null)
                    _smallProvod.transform.localRotation = Quaternion.Euler(0, y, 0);
                y++;
                yield return new WaitForSeconds(0.01f);

            }
        }
        else
        {
            int y = 90;
            while (y >= 0)
            {
                _door.transform.localRotation = Quaternion.Euler(0, y, 0);
                if (_bigProvod != null)
                    _bigProvod.transform.localRotation = Quaternion.Euler(0, y-90, 0);
                if (_midProvod != null)
                    _midProvod.transform.localRotation = Quaternion.Euler(0, y, 0);
                if (_smallProvod != null)
                    _smallProvod.transform.localRotation = Quaternion.Euler(0, y-20, 0);
                y--;
                yield return new WaitForSeconds(0.01f);

            }
            if(_smallDoor)
            _door.transform.localRotation = Quaternion.Euler(0, 0.3f, 0);
        }
        canAction = true;
    }
}
