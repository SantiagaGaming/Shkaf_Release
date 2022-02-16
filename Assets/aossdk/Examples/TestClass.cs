using AosSdk.Core.Interfaces;
using AosSdk.Core.Scripts;
using UnityEngine;

namespace AosSdk.Examples
{
    [AosObject(name: "Тестовый объект")]
    public class TestClass : AosObjectBase, IClickAble, IHoverAble
    {
        [AosAction(name: "Тестовый экшен параметрами")]
        public void TestVoidWithParameters([AosParameter("Аргумент 1")] bool arg1, [AosParameter("Аргумент 2")] int arg2,
            [AosParameter("Аргумент 3")] float arg3)
        {
        }

        [AosAction(name: "Тестовый экшен без параметров")]
        public void TestVoid()
        {
        }


        [AosEvent(name: "Тестовое событие")] 
        public event AosEventHandler OnEventHappened;

        private void Start()
        {
            OnEventHappened += () => { Debug.Log("Test class event fired"); };
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.T))
            {
                OnEventHappened?.Invoke();
            }
        }

        [AosAction("Do magic void")]
        public void DoMagic(bool first, int second, string third)
        {
            Debug.Log($"first = {first}, second = {second}, third = {third}");
        }

        public void OnClicked()
        {
            Debug.Log($"{gameObject.name} clicked");
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