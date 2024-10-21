using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace Tests
{
    public class StickInput : MonoBehaviour
    {
        [SerializeField]
        protected Transform spritePosition;
        
        [SerializeField]
        [Range(0, 1)]
        protected float offsetAmount = 1;
        
        protected bool _touched = false;
        protected StickControl _stickControl;
        
        public void SetStickControl(StickControl stickControl, string buttonText = "")
        {
            _touched = false;
            _stickControl = stickControl;
        }
        
        public virtual void Reset()
        {
            _touched = false;
            _stickControl = null;
            spritePosition.localRotation = Quaternion.identity;
        }
        
        private void Awake()
        {
            Reset();
        }

        // Update is called once per frame
        void Update()
        {
            if (_stickControl == null) return;
            OnUpdate();
        }
        
        protected virtual void OnUpdate()
        {
            Vector2 stickPos = _stickControl.value;
            Vector3 rotation = new Vector3(stickPos.y * offsetAmount * -90, stickPos.x * offsetAmount * -90, 0);
            //Debug.Log(rotation);

            spritePosition.localRotation = Quaternion.Euler(rotation);
        }
    }
}
