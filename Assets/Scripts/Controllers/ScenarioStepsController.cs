using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioStepsController : MonoBehaviour
{
    [SerializeField] private ScenarioStep[] _scenarioSteps;

    private int _currentScenarioStep;
    private void Start()
    {
        foreach (var scenarioStep in _scenarioSteps)
        {
            scenarioStep.EndScenarioStepEvent += OnEndScenarioStep;
        }
        _scenarioSteps[_currentScenarioStep].StartScenarioStep();
    }

    private void OnEndScenarioStep()
    {
        _scenarioSteps[_currentScenarioStep].EndScenarioStepEvent -= OnEndScenarioStep;
        _currentScenarioStep++;
        _scenarioSteps[_currentScenarioStep].StartScenarioStep();
    }
    public ScenarioStep GetCurrentScenarionStep()
    {
        return _scenarioSteps[_currentScenarioStep];
    }
    public int GetScenarioStepIndex()
    {
        return _currentScenarioStep;
    }

}
