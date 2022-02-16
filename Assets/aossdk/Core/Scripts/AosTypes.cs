using System;

namespace AosSdk.Core.Scripts
{
    [Serializable]
    public class AosObjectType
    {
        public string aosObjectDescription;
        public string aosObjectGuid;
        public AosActionType[] aosObjectActions;
        public AosEventType[] aosObjectEvents;
    }
    
    [Serializable]
    public class AosActionType
    {
        public string methodDescription;
        public string methodName;
        public AosActionParameterInfoType[] parameters;
    }

    [Serializable]
    public class AosActionParameterInfoType
    {
        public string parameterDescription;
        public string parameterName;
        public string parameterType;
    }

    [Serializable]
    public class AosEventType
    {
        public string eventDescription;
        public string eventName;
    }
    
    [Serializable]
    public class AosCommand
    {
        public string objectGuid;
        public string methodName;
        public AosParameterType[] parameters;
        public float delay;
        public object[] CastedParameters;

        public void CastParameters()
        {
            CastedParameters = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                var value = parameters[i].parameterValue;
                CastedParameters[i] = parameters[i].parameterType switch
                {
                    "Boolean" => bool.Parse(value),
                    "Int32" => int.Parse(value),
                    "Single" => float.Parse(value),
                    "String" => value,
                    _ => CastedParameters[i]
                };
            }
        }
    }

    [Serializable]
    public class AosParameterType
    {
        public string parameterName;
        public string parameterType;
        public string parameterValue;
    }

    public class EventHandlerHelper
    {
        public string GameObjectGuid;
        public string EventName;
    }

    public enum ServerMessageType
    {
        Callback,
        Event,
        Error
    }

    [Serializable]
    public class ServerMessage
    {
        public string type;
        public string objectGuid;
    }

    [Serializable]
    public class ServerMessageError : ServerMessage
    {
        public string errorMessage;
    }

    [Serializable]
    public class ServerMessageCallback : ServerMessage
    {
        public string invokedMethod;
        public bool isSuccess;
    }

    [Serializable]
    public class ServerMessageEvent : ServerMessage
    {
        public string eventName;
    }
}