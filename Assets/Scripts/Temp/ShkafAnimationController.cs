using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShkafAnimationController : BaseObject
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
public void PlayOpenLockerAnimation()
    {
        _animator.SetTrigger("Locker");
        StartCoroutine(InvokeEndAction());
    }
    public void PlayOpenDoorAnimation()
    {
        _animator.SetTrigger("OpenDoor");
        StartCoroutine(InvokeEndAction());
    }
    public IEnumerator InvokeEndAction()
    {
        yield return new WaitForSeconds(3f);
        EndActionEvent?.Invoke();
    }

}
