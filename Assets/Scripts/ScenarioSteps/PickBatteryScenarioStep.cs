using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBatteryScenarioStep : ScenarioStep
{
    [SerializeField] private VoicePlayer _voicePlayer;
    [SerializeField] private PickableController _pickableController;
    [SerializeField] private PlayerInventory _playerInventory;

    private bool _batteryStep = false;
    private void OnEnable()
    {
        _pickableController.ItemPickedEvent += OnCheckStep;
    }
    private void OnDisable()
    {
        _pickableController.ItemPickedEvent -= OnCheckStep;
    }
    public override void StartScenarioStep()
    {
        StartCoroutine(PlayVoicewithDelay());
    }
    private IEnumerator PlayVoicewithDelay()
    {
        yield return new WaitForSeconds(1.5f);
        _voicePlayer.StopAudioSource();
        _voicePlayer.PlayPickObjectsVoice();
    }
    private void OnCheckStep()
    {
        if (_playerInventory.GetItemName("Battery") && !_batteryStep)
        {
            EndScenarioStepEvent?.Invoke();
            _batteryStep = true;
        }
    }
}
