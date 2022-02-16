
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseObject : MonoBehaviour
{
    [SerializeField] private string _objectName;
    public UnityAction EndActionEvent;
    
    public virtual void StartAction()
    {
       
    }
    public virtual void RevertAction()
    {

    }
    public override string ToString()
    {
        return _objectName;
    }
}
