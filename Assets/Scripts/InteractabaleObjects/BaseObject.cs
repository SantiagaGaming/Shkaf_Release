
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseObject : MonoBehaviour
{
    [SerializeField] private string _objectName;
    public UnityAction EndActionEvent;
    
    public virtual void StartAction()
    {
       
    }
    public override string ToString()
    {
        return _objectName;
    }
}
