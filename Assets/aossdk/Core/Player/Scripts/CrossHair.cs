using UnityEngine;
using UnityEngine.UI;

namespace AosSdk.Core.Player.Scripts
{
    public enum CrossHairState
    {
        Default,
        Hovered,
        Unknown
    }

    public class CrossHair : MonoBehaviour
    {
        public Image crossHair;

        public Sprite CrossHairDefaultSprite{ private get; set; }
        public Sprite CrossHaiHoveredSprite{ private get; set; }

        public float CrossHairSizeMultiplier { private get; set; }

        private CrossHairState _currentState = CrossHairState.Unknown;
        
        private void Start()
        {
            SetCrossHairSize();
            SetState(CrossHairState.Default);
        }

        private void SetCrossHairSize()
        {
            var size = (float) Screen.width * 1 / 100 * CrossHairSizeMultiplier;
            crossHair.rectTransform.sizeDelta = new Vector2(size, size);
        }

        public void SetState(CrossHairState state)
        {
            if (state == _currentState)
            {
                return;
            }

            crossHair.sprite = state == CrossHairState.Default ? CrossHairDefaultSprite : CrossHaiHoveredSprite;
            _currentState = state;
        }
    }
}