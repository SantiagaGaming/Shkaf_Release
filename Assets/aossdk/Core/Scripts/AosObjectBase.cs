using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Core.Scripts
{
    [DisallowMultipleComponent]
    public class AosObjectBase : MonoBehaviour
    {
        #if UNITY_EDITOR
        [ReadOnly]
        #endif
        public string objectStaticGuid = string.Empty;

        public delegate void AosEventHandler();

        public static void InheritEventFired(EventHandlerHelper helper)
        { 
            WebSocketWrapper.Instance.DoSendMessage(new ServerMessageEvent
            {
                type = ServerMessageType.Event.ToString(),
                eventName = helper.EventName,
                objectGuid = helper.GameObjectGuid
            });
        }

        public void OnEnable()
        {
            foreach (var eventInfo in GetType().GetEvents())
            {
                if (!(Attribute.GetCustomAttribute(eventInfo, typeof(AosEvent)) is AosEvent))
                {
                    continue;
                }

                var handlerType = eventInfo.EventHandlerType;
                var eventHandler = GetType().GetMethod("InheritEventFired",
                    BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static);
                eventInfo.AddEventHandler(this,
                    Delegate.CreateDelegate(handlerType,
                        new EventHandlerHelper {GameObjectGuid = objectStaticGuid, EventName = eventInfo.Name},
                        eventHandler ?? throw new InvalidOperationException()));
            }
        }

        private readonly List<AosCommand> _commandQueue = new List<AosCommand>();

        public void QueueCommand(AosCommand command)
        {
            _commandQueue.Add(command);
        }

        private void FixedUpdate()
        {
            if (_commandQueue.Count <= 0)
            {
                return;
            }

            StartCoroutine(ExecuteCommandRoutine(_commandQueue[0]));
            // TODO stop coroutine if new is invoking
            _commandQueue.RemoveAt(0);
        }

        private IEnumerator ExecuteCommandRoutine(AosCommand command)
        {
            yield return new WaitForSeconds(command.delay);
            
            command.CastParameters();

            var parametersType = new Type[command.CastedParameters.Length];

            for (var i = 0; i < command.CastedParameters.Length; i++)
            {
                parametersType[i] = command.CastedParameters[i].GetType();
            }

            var methodInfo = GetType().GetMethod(command.methodName, parametersType);
            if (methodInfo == null)
            {
                // TODO exception
                Debug.LogError("Method not found");
                yield break;
            }

            methodInfo.Invoke(this, command.CastedParameters);
            
            WebSocketWrapper.Instance.DoSendMessage(new ServerMessageCallback
            {
                objectGuid = objectStaticGuid,
                invokedMethod = methodInfo.Name,
                isSuccess = true,
                type = ServerMessageType.Callback.ToString()
                // TODO implement cases with isSuccess = false
            });
        }

        protected void ReportError(string errorMessage)
        {
            WebSocketWrapper.Instance.DoSendMessage(new ServerMessageError
            {
                objectGuid = objectStaticGuid,
                errorMessage = errorMessage,
                type = ServerMessageType.Error.ToString()
            });
        }
    }
}