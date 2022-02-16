using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScenarioStep : ScenarioStep
{
    [SerializeField] private VoicePlayer _voicePlayer;

    public override void StartScenarioStep()
    {
        _voicePlayer.StopAudioSource();
        _voicePlayer.PlayEndTrainingVoice();
    }

}
