using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace Tests
{
    public class ButtonPressed : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer sprite;
        [SerializeField]
        private Color untouchedColor = new Color(0.7f, 0.2f, 0.2f);
        [SerializeField]
        private Color activeColor = new Color(0.4f, 0.47f, 0.9f);
        [SerializeField]
        private Color touchedColor = new Color(0.3f, 0.6f, 0.3f);
        
        [SerializeField]
        private TextMeshPro text;

        private bool _touched = false;
        
        private ButtonControl _buttonControl;
        
        public void SetButtonControl(ButtonControl buttonControl, string buttonText = "")
        {
            _buttonControl = buttonControl;
            text.text = buttonText;
        }

        private void Awake()
        {
            text.text = "";
            Reset();
        }

        public void Reset()
        {
            _touched = false;
            sprite.color = untouchedColor;
            _buttonControl = null;
        }

        void Update()
        {
            if (_buttonControl == null) return;
            
            var color = _touched ? touchedColor : untouchedColor;
            if (_buttonControl.isPressed)
            {
                _touched = true;
                color = activeColor;
            }

            sprite.color = color;
        }
    }
}
