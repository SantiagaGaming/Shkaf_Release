using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickOscilScenarioStep : ScenarioStep
{
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private PickableController _pickableController;
    [SerializeField] private PlayerInventory _playerInventory;

    private bool _oscilStep = false;
    public override void StartScenarioStep()
    {
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
        if (_playerInventory.GetItemName("Oscil"))
        {
            steps++;

        }

        CheckFinishStep();
    }
    private void CheckFinishStep()
    {

        if (steps == 1 && !_oscilStep)
        {
            EndScenarioStepEvent?.Invoke();
            _oscilStep = true;
        }
    }
}
