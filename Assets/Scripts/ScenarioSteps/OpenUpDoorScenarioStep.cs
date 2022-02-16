using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpDoorScenarioStep : ScenarioStep
{
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private NextStepObject _upDoorObject;
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private FlyCamera _flyCamera;
    [SerializeField] private PlayerCanvasViev _playerCnvasViev;

    private int _currentImage;

    public override void StartScenarioStep()
    {
        _voicePlayer.StopAudioSource();
        _upDoorObject.GetComponent<BoxCollider>().enabled = true;
        _voicePlayer.PlayUpDoorWalkVoice();
        _upDoorObject.AllowClick();
    }
    private void OnEnable()
    {
        _upDoorObject.StepEvent += OnStartAction;
    }
    private void OnDisable()
    {
        _upDoorObject.StepEvent -= OnStartAction;
    }
    private void OnStartAction()
    {
        _cameraSwitcher.SwitchCamera(true);
        StartNextAction();
    }
    public override void StartNextAction()
    {
        if (steps == 0)
        {
            _flyCamera.FlyToUpDoorPostition();
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayCircleKeyOpenDoorVoice();
        }
       else if(steps ==1)
        {
            TryGetBaseObject("UpDoorKey1").StartAction(); ;
            StartActionEvent?.Invoke();
        }
        else if(steps == 2)
        {
            TryGetBaseObject("UpDoorKey2").StartAction(); ;
            StartActionEvent?.Invoke();
        }
        else if(steps==3)
        {
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayOpenDoorVoice();
        }
        else if(steps==4)
        {
            TryGetBaseObject("DoorUp").StartAction(); ;
            StartActionEvent?.Invoke();
        }
        else if(steps==5)
        {
            _playerCnvasViev.ShowOscilImage(true);
            _playerCnvasViev.ChangeOscilSprite(_currentImage);

        }
        else if(steps<=11)
        {
            _currentImage++;
            _playerCnvasViev.ChangeOscilSprite(_currentImage);
        }
    else if(steps==12)
        {
            _playerCnvasViev.ShowOscilImage(false);
            _cameraSwitcher.SwitchCamera(false);
            EndScenarioStepEvent?.Invoke();
        }


        steps++;
    }
}
