using UnityEngine;

namespace Tests
{
    public class LinerInput : ButtonPressed
    {
        protected override void OnColorUpdate()
        {
            var color = Color.clear;
            
            float strength = _buttonControl.value;
            if (strength < 0.01f)
            {
                strength = 0;
            }
            color = activeColor;
            color.a = strength;
            sprite.color = color;
            text.text = $"{Mathf.RoundToInt(strength * 100)}%";
        }

        public override void Reset()
        {
            base.Reset();
            sprite.color = Color.clear;
            text.text = $"0%";
        } 
    }
}
