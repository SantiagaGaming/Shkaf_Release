using AosSdk.Core.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace AosSdk.Core.Player.Scripts
{
    public class RayCaster : MonoBehaviour
    {
        public float InteractDistance { private get; set; }
        public CrossHair CrossHair { private get; set; }
        public Transform CameraTransform { private get; set; }

        private Collider _currentInteractAble;
        private IClickAble _currentClickAble;
        private IHoverAble _currentHoverAble;
        
        private void Update()
        {
            if (!Physics.Raycast(CameraTransform.position, CameraTransform.TransformDirection(Vector3.forward), out var hit,
                InteractDistance))
            {
                _currentHoverAble?.OnHoverOut();
                
                _currentInteractAble = null;
                _currentClickAble = null;
                _currentHoverAble = null;
                
                CrossHair.SetState(CrossHairState.Default);
                return;
            }
            
            if (hit.collider != _currentInteractAble)
            {
                _currentHoverAble?.OnHoverOut();
                
                _currentClickAble = hit.collider.gameObject.GetComponent<IClickAble>();
                _currentHoverAble = hit.collider.gameObject.GetComponent<IHoverAble>();
                
                _currentHoverAble?.OnHoverIn();

                if (_currentClickAble != null || _currentHoverAble != null)
                {
                    CrossHair.SetState(CrossHairState.Hovered);
                    
                    if (Input.GetMouseButtonUp((int) MouseButton.LeftMouse))
                    {
                        _currentClickAble?.OnClicked();
                    }
                    
                    return;
                }

                CrossHair.SetState(CrossHairState.Default);
            }
            
            _currentInteractAble = hit.collider;
        }
    }
}
