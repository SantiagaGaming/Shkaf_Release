using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCircleKeyScenarioStep : ScenarioStep
{
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private PickableController _pickableController;
    [SerializeField] private PlayerInventory _playerInventory;

    private bool _circleKeyStep = false;
    public override void StartScenarioStep()
    {
        _voicePlayer.StopAudioSource();
        _voicePlayer.PlayPickObjectsVoice();
    }
    private void OnEnable()
    {
        _pickableController.ItemPickedEvent += OnCheckStep;
    }
    private void OnDisable()
    {
        _pickableController.ItemPickedEvent += OnCheckStep;
    }
    private void OnCheckStep()
    {
        if (_playerInventory.GetItemName("CircleKey"))
        {
            steps++;
        }

        CheckFinishStep();
    }
    private void CheckFinishStep()
    {
        if (steps == 1 && !_circleKeyStep)
        {
            EndScenarioStepEvent?.Invoke();
            _circleKeyStep = true;
        }
    }
}
