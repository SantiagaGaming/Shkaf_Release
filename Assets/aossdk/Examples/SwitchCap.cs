using AosSdk.Core.Interfaces;
using UnityEngine;

namespace AosSdk.Examples
{
    public class SwitchCap : MonoBehaviour, IClickAble, IHoverAble
    {
        public delegate void CapEventHandler();

        public event CapEventHandler OnCapOpened;
    
        public void OnClicked()
        {
            OnCapOpened?.Invoke();
        }

        public void OnHoverIn()
        {
            GetComponent<Renderer>().material.color /= 2;
        }

        public void OnHoverOut()
        {
            GetComponent<Renderer>().material.color *= 2;
        }
    }
}