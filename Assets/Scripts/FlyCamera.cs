using UnityEngine;

public class FlyCamera : MonoBehaviour
{

    [SerializeField] private Transform _upBoltPosition;
    [SerializeField] private Transform _downBoltPosition;
    [SerializeField] private Transform _lockerPosition;
    [SerializeField] private Transform _openDoorPosition;
    [SerializeField] private Transform _klemmPosition;
    [SerializeField] private Transform _batteryPosition;
    [SerializeField] private Transform _oscilPosition;
    [SerializeField] private Transform _oscilx2x3Position;
    [SerializeField] private Transform _upDoorPosition;
    private Transform _newPos;
    private void Start()
    {
        _newPos = GetComponent<Transform>();
    }
   private void Update()
    {
        FlyToPosition();
    }
    private void FlyToPosition()
    {
        transform.position = Vector3.Lerp(transform.position, _newPos.transform.position, 0.02f);
        transform.rotation = Quaternion.Slerp(transform.rotation, _newPos.transform.rotation, 0.02f);
    }
    public void FlyToUpBolt()
    {
        _newPos = _upBoltPosition;
    }
    public void FlyToDownBolt()
    {
        _newPos = _downBoltPosition;
    }
    public void FlyToLocker()
    {
        _newPos = _lockerPosition;
    }
    public void FlyToOpenDoor()
    {
        _newPos = _openDoorPosition;
    }
    public void FlyToKlemm()
    {
        _newPos = _klemmPosition;
    }
    public void FlyToBattery()
    {
        _newPos = _batteryPosition;
    }
    public void FlyToOscil()
    {
        _newPos = _oscilPosition;
    }
    public void FlyToOscilx2x3()
    {
        _newPos = _oscilx2x3Position;
    }
    public void FlyToUpDoorPostition()
    {
        _newPos = _upDoorPosition;
    }

}
