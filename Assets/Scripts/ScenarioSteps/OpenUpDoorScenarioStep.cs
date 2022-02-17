using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpDoorScenarioStep : ScenarioStep
{
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private NextStepObject _upDoorObject;
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private FlyCamera _flyCamera;
    [SerializeField] private PlayerCanvasViev _playerCanvasViev;
    [SerializeField] private GameObject _upLock;
    [SerializeField] private GameObject _downLock;


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
            TryGetBaseObject("UpDoorKey1").StartAction(); 
            StartActionEvent?.Invoke();
            _upLock.transform.localRotation = Quaternion.Euler(90, 0, 0);
        }
        else if(steps == 2)
        {
            TryGetBaseObject("UpDoorKey2").StartAction(); 
            StartActionEvent?.Invoke();
            _downLock.transform.localRotation = Quaternion.Euler(90, 0, 0);
        }
        else if(steps==3)
        {
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayOpenDoorVoice();
        }
        else if(steps==4)
        {
            TryGetBaseObject("DoorUp").StartAction();
            StartActionEvent?.Invoke();
        }
        else if(steps==5)
        {
            _flyCamera.FlyToUpDoorCloserPosition();
            _playerCanvasViev.ShowHandImage(true);
        }
        else if (steps == 6)
        {
            _playerCanvasViev.ShowHandImage(false);
            TryGetBaseObject("Button").StartAction();
            StartActionEvent?.Invoke();
        }
        else if (steps == 7)
        {
            _playerCanvasViev.ShowOscilImage(true);
            _playerCanvasViev.ChangeOscilSprite(_currentImage);

        }
        else if (steps <= 13)
        {
            _currentImage++;
            _playerCanvasViev.ChangeOscilSprite(_currentImage);
        }

        else if(steps==14)
        {
            _playerCanvasViev.ShowOscilImage(false);
            _currentImage = 0;
            _flyCamera.FlyToOscilx2x3();
        }
        else if(steps==15)
        {
            TryGetBaseObject("WireBlack").RevertAction();
            StartActionEvent?.Invoke();
        }
        else if(steps==16)
        {
            TryGetBaseObject("WireRed").RevertAction();
            StartActionEvent?.Invoke();
        }
        else if (steps == 17)
        {
            TryGetBaseObject("WireBlack").StartAction();
            StartActionEvent?.Invoke();
        }
        else if (steps == 18)
        {
            TryGetBaseObject("WireRed").StartAction();
            StartActionEvent?.Invoke();
        }
        else if(steps==19)
        {
            _flyCamera.FlyToUpDoorCloserPosition();
        
        }
        else if(steps==20)
        {
            _playerCanvasViev.ShowHandImage(true);
        }
        else if(steps==21)
        {
            _playerCanvasViev.ShowHandImage(false);
            TryGetBaseObject("Button").StartAction();
            StartActionEvent?.Invoke();
        }

        else if(steps==22)
        {
            _playerCanvasViev.ShowOscilImage(true);
            _playerCanvasViev.ChangeOscilSprite(_currentImage);

        }
        else if(steps<=28)
        {
            _currentImage++;
            _playerCanvasViev.ChangeOscilSprite(_currentImage);
        }
    else if(steps==29)
        {
            _playerCanvasViev.ShowOscilImage(false);
            _cameraSwitcher.SwitchCamera(false);
            EndScenarioStepEvent?.Invoke();
        }
        steps++;
    }
}
