using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Core.Scripts
{
    public class AosCommandQueueHandler : MonoBehaviour
    {
        public CommandList<AosCommand> CommandQueue
        {
            get;
        } = new CommandList<AosCommand>();

        private AosObjectBase[] _aosObjects;

        private void Start()
        {
            CommandQueue.OnItemAdded += CommandQueueOnOnItemAdded;
            _aosObjects = FindObjectsOfType<AosObjectBase>();
        }

        private void CommandQueueOnOnItemAdded(AosCommand command)
        {
            
            foreach (var aosObject in _aosObjects)
            {
                if (aosObject.objectStaticGuid != command.objectGuid)
                {
                    continue;
                }

                aosObject.QueueCommand(command);
                
                CommandQueue.Remove(command);
                
                return;
            }
            
            WebSocketWrapper.Instance.DoSendMessage(new ServerMessageError
            {
                objectGuid = null,
                type = ServerMessageType.Error.ToString(),
                errorMessage = $"Object with guid {command.objectGuid} not found on scene"
            });
        }
    }

    
}

