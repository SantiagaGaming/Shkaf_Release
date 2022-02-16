using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerristerScenarioStep : ScenarioStep
{
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private NextStepObject _terristerObject;
    [SerializeField] private FlyCamera _flyCamera;
    [SerializeField] private PlayerCanvasViev _playerCnvasViev;
    [SerializeField] private CameraSwitcher _cameraSwitcher;

    public override void StartScenarioStep()
    {
        _voicePlayer.StopAudioSource();
        _voicePlayer.PlayGoToTerristerVoice();
        _terristerObject.AllowClick();
    }
    private void OnEnable()
    {
        _terristerObject.StepEvent += OnStartAction;
    }
    private void OnDisable()
    {
        _terristerObject.StepEvent -= OnStartAction;
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
            _flyCamera.FlyToShkafBackPosition();
        }
        else if(steps ==1)
        {
            _flyCamera.FlyToTerristerPosition();
        }
        else if(steps==2)
        {
            _flyCamera.FlyToTerristerMeasurePosition();
        }
        else if (steps == 3)
        {
            _flyCamera.FlyToUpDoorPostition();
        }
        else if(steps==4)
        {
            _playerCnvasViev.ShowOscilImage(true);
            _playerCnvasViev.ChangeOscilSprite(0);
        }
        else if (steps == 5)
        {
            _playerCnvasViev.ShowOscilImage(true);
            _playerCnvasViev.ChangeOscilSprite(4);
        }
        else if(steps ==6)
        {
            _playerCnvasViev.ShowOscilImage(false);
            _cameraSwitcher.SwitchCamera(false);
            EndScenarioStepEvent?.Invoke();
        }
        steps++;
    }
}