using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandObject : BaseObject
{
    [SerializeField] private GameObject _hand;

    public override void StartAction()
    {

        StartCoroutine(MoveHand());
    }

    private IEnumerator MoveHand()
    {
        _hand.SetActive(true);
        int z = 0;
        while (z<=31)
        {
            transform.position -= new Vector3(0, 0, 0.01f);
            z++;
            yield return new WaitForSeconds(0.06f);
        }
        while( z>=0)
        {
            transform.position += new Vector3(0, 0, 0.01f);
            z--;
            yield return new WaitForSeconds(0.06f);
        }
        _hand.SetActive(false);
        EndActionEvent?.Invoke();
    }
}
