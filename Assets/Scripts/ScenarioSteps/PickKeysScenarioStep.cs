using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKeysScenarioStep : ScenarioStep
{
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private PickableController _pickableController;
    [SerializeField] private PlayerInventory _playerInventory;

    private bool _keysStep = false;
    public override void StartScenarioStep()
    {
        _voicePlayer.PlayPickObjectsForDoorVoice();
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
       if (_playerInventory.GetItemName("Magnet"))
        {
            steps++;
      
        }
      else if(_playerInventory.GetItemName("Key"))
        {
            steps++;
       
        }

        CheckFinishStep();
    }
    private void CheckFinishStep()
    {
      
        if (steps ==2 && !_keysStep)
        {
            EndScenarioStepEvent?.Invoke();
            _keysStep = true;
        }
    }
}
