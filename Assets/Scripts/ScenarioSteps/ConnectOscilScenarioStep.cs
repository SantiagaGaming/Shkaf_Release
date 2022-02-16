using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectOscilScenarioStep : ScenarioStep
{
    [SerializeField] private FlyCamera _flyCamera;
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private NextStepObject _plateObject;
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    public override void StartScenarioStep()
    {
        _voicePlayer.StopAudioSource();
        _voicePlayer.PlayGoToPlateVoice();
        _plateObject.AllowClick();
    }
    private void OnEnable()
    {
        _plateObject.StepEvent += OnStartAction;
    }
    private void OnDisable()
    {
        _plateObject.StepEvent -= OnStartAction;
    }
    private void OnStartAction()
    {
        _cameraSwitcher.SwitchCamera(true);
        _flyCamera.FlyToOscil();
        _voicePlayer.StopAudioSource();
        _voicePlayer.PlayConnectOscilVoice();
    }
    public override void StartNextAction()
    {
        if (steps == 0)
        {
            _flyCamera.FlyToOscilx2x3();
        }
        else if(steps==1)
        {
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayOscilPlateConnectVoice();
        }
        else if(steps==2)
        {
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayBlackWireConnectVoice();
        }
        else if(steps ==3)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("WireBlack").StartAction();
        }
        else if(steps==4)
        {
            _voicePlayer.StopAudioSource();
            _voicePlayer.PlayRedWireConnectVoice();
        }
        else if(steps==5)
        {
            StartActionEvent?.Invoke();
            TryGetBaseObject("WireRed").StartAction();
        }
        else if(steps == 6)
        {
            _voicePlayer.PlayWireConnectedDoneVoice();
            _cameraSwitcher.SwitchCamera(false);
            EndScenarioStepEvent?.Invoke();
        }
        steps++;
    }
}
