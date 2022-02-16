using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShkafCanvasController : MonoBehaviour
{
    [SerializeField] private ShkafCanvasViev _shkafCanvasViev;
    [SerializeField] private ScenarioStepsController _scenarioStepsController;
    [SerializeField] private ScenarioStep[] _scenarionSteps;
    [SerializeField] private BaseObject[] _baseObjects;
    [SerializeField] private SoundPlayer _soundPlayer;
    private void Start()
    {
        foreach (var scenarioStep in _scenarionSteps)
        {
            scenarioStep.StartActionEvent += OnDisableNextButton;
        }
        foreach (var baseObject in _baseObjects)
        {
            baseObject.EndActionEvent += OnEnableNextButton;
        }
    }
    private void OnEnable()
    {
        _shkafCanvasViev.NextButtonTapEvent += OnStartNextScenarionAction;
    }
    private void OnDisable()
    {
        _shkafCanvasViev.NextButtonTapEvent -= OnStartNextScenarionAction;
    }
    private void OnStartNextScenarionAction()
    {
        _scenarioStepsController.GetCurrentScenarionStep().StartNextAction();
        _soundPlayer.PlayClickSound();
    }
    private void OnEnableNextButton()
    {
        _shkafCanvasViev.NextButtonEnabler(true);
    }
    private void OnDisableNextButton()
    {
        _shkafCanvasViev.NextButtonEnabler(false);
    }
}
