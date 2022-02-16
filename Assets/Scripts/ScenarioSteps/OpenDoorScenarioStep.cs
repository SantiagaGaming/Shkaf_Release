using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenDoorScenarioStep : ScenarioStep
{
    [SerializeField] private FlyCamera _flyCamera;
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private GameObject _magnetKey;
    [SerializeField] private GameObject _key;
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private NextStepObject _doorObject;

  
    public override void StartScenarioStep()
    {
        _voicePlayer.StopAudioSource();
        _voicePlayer.PlayStartOpenDoorVoice();
        _doorObject.AllowClick();
    }
    private void OnEnable()
    {
        _doorObject.StepEvent += OnStartAction;
    }
    private void OnDisable()
    {
        _doorObject.StepEvent -= OnStartAction;
    }
    private void OnStartAction()
    {
        _cameraSwitcher.SwitchCamera(true);
    }
    public override void StartNextAction()
    {
        if(steps ==0)
        {
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayUpLockerVoice();
            _flyCamera.FlyToUpBolt();
        }
       else  if(steps ==1)
        {
            TryGetBaseObject("VentTop").StartAction();
            StartActionEvent?.Invoke();
        }
        else if(steps ==2)
        {
            _flyCamera.FlyToDownBolt();
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayDownLockerVoice();
        }
        else if(steps==3)
        {
            TryGetBaseObject("VentBottom").StartAction();
            StartActionEvent?.Invoke();
        }
        else if (steps==4)
        {
            _voicePlayer.StopAudioSource();
            _flyCamera.FlyToLocker();
            _voicePlayer.PlayMagnetVoice();
            _magnetKey.SetActive(true);
        }
        else if(steps ==5)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("MagnetKey").StartAction();
        }
        else if(steps == 6)
        {
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayMidLockerVoice();
            _magnetKey.SetActive(true);
        }
        else if(steps ==7)
        {
            _key.SetActive(true);
            StartActionEvent?.Invoke();
            TryGetBaseObject("Zamok").StartAction();

        }
        else if(steps ==8)
        {
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayOpenDoorVoice();
        }
        else if(steps ==9)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("Door").StartAction();
            _flyCamera.FlyToOpenDoor();
        }
        else if(steps ==10)
        {
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayDoorIsOpenVoice();
            _cameraSwitcher.SwitchCamera(false);
            EndScenarioStepEvent?.Invoke();
        }
        steps++;
     
    }

}
