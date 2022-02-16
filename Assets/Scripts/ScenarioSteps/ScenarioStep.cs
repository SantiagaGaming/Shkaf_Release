using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public abstract class ScenarioStep : MonoBehaviour
{
    public UnityAction StartActionEvent;
    public UnityAction EndScenarioStepEvent;

    [SerializeField] private BaseObject[] _objects;

    protected int steps;
    public virtual void StartScenarioStep()
    {

    }
    public virtual void EndScenerioStep()
    {
        EndScenarioStepEvent?.Invoke();
    }
    public virtual void StartNextAction()
    {

    }
    protected BaseObject TryGetBaseObject(string name)
    {
       var result = _objects.FirstOrDefault(p => p.ToString() == name);
        return result;
    }
}
