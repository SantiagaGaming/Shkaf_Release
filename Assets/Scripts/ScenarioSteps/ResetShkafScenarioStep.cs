using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetShkafScenarioStep : ScenarioStep
{
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private NextStepObject _shkafObject;
    [SerializeField] private FlyCamera _flyCamera;
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private GameObject _magnet;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _wire1;
    [SerializeField] private GameObject _wire2;

    public override void StartScenarioStep()
    {
        _voicePlayer.StopAudioSource();
        _voicePlayer.PlayResetShkafVoice();
        _shkafObject.GetComponent<BoxCollider>().enabled = true;
        _shkafObject.AllowClick();
    }
    private void OnEnable()
    {
        _shkafObject.StepEvent += OnStartAction;
    }
    private void OnDisable()
    {
        _shkafObject.StepEvent -= OnStartAction;
    }
    private void OnStartAction()
    {
        _cameraSwitcher.SwitchCamera(true);
        _shkafObject.GetComponent<BoxCollider>().enabled = false;
        StartNextAction();
    }
    public override void StartNextAction()
    {
        if (steps == 0)
        {
            _flyCamera.FlyToUpDoorPostition();
        }
       else if(steps==1)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("DoorUp").RevertAction();
     
        }
        else if(steps ==2)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("UpDoorKey2").RevertAction();
   
        }
        else if(steps==3)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("UpDoorKey1").RevertAction();
         
        }
        else if (steps == 4)
        {
            _flyCamera.FlyToBattery();
   
        }
        else if(steps==5)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("Battery").RevertAction();
 
        }
        else if (steps == 6)
        {
            _flyCamera.FlyToOpenDoor();
        }
        else if(steps==7)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("Door").RevertAction();

        }
        else if(steps==8)
        {
            _wire1.SetActive(false);
            _wire2.SetActive(false);
            _flyCamera.FlyToLocker();
        }
        else if(steps ==9)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("Zamok").RevertAction();
    
        }
        else if(steps==10)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("MagnetKey").RevertAction();
            _key.SetActive(false);
        }
        else if (steps == 11)
        {
            _magnet.SetActive(false);
            _flyCamera.FlyToDownBolt();
        }
        else if(steps==12)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("VentBottom").RevertAction();
        }
        else if(steps==13)
        {
            _flyCamera.FlyToUpBolt();
        }
        else if(steps==14)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("VentTop").RevertAction();
    
        }
        else if(steps==15)
        {
            _flyCamera.FlyToOpenDoor();
        }
        else if(steps==16)
        {
            _cameraSwitcher.SwitchCamera(false);
            EndScenarioStepEvent?.Invoke();
        }

        steps++;
    }

  }
