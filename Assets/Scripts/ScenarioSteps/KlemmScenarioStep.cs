using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlemmScenarioStep :ScenarioStep
{
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private NextStepObject _klemmObject;
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private FlyCamera _flyCamera;
    public override void StartScenarioStep()
    {
        _voicePlayer.StopAudioSource();
        _voicePlayer.PlayKlemmVoice();
        _klemmObject.AllowClick();
    }
    private void OnEnable()
    {
        _klemmObject.StepEvent += OnStartAction;
    }
    private void OnDisable()
    {
        _klemmObject.StepEvent -= OnStartAction;
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
            _flyCamera.FlyToKlemm();
     
        }
        else if (steps == 1)
        {
            _voicePlayer.PlayKlemPowerVoice();
        
        }
        else if(steps ==2)
        {
            TryGetBaseObject("Tumbler").StartAction(); ;
            StartActionEvent?.Invoke();
        }
        else if(steps ==3)
        {
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayBatteryPowerVoice();
            _flyCamera.FlyToBattery();
        }
        else if (steps == 4)
        {
            TryGetBaseObject("Battery").StartAction();
            StartActionEvent?.Invoke();
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayBatteryPowerOnVoice();
        }
        else if(steps == 5)
        {
            _cameraSwitcher.SwitchCamera(false);
            EndScenarioStepEvent?.Invoke();
        }
        steps++;
    }
}
