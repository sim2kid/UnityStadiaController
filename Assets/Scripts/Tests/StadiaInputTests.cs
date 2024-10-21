using System.Linq;
using sim2kid.Package.StadiaInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tests
{
    public class StadiaInputTests : MonoBehaviour
    {
        public StadiaController Controller { get; private set; }

        [SerializeField]
        private ButtonPressed north;
        [SerializeField]
        private ButtonPressed east; 
        [SerializeField]
        private ButtonPressed south;
        [SerializeField]
        private ButtonPressed west; 
        
        [SerializeField]
        private ButtonPressed DUp;
        [SerializeField]
        private ButtonPressed DRight;
        [SerializeField]
        private ButtonPressed DDown;
        [SerializeField]
        private ButtonPressed DLeft;
        
        void Update()
        {
            FindController();
        }

        private void FindController()
        {
            var controller = InputSystem.devices.FirstOrDefault(device => device is StadiaController);
            if (controller == Controller)
            {
                return;
            }
            else if (Controller != null)
            {
                Controller = null;
                Debug.Log($"Stadia Controller Disconnected.");
                Reset();
            }
            if (controller is not StadiaController stadiaController) return;
            Controller = stadiaController;
            Debug.Log($"Stadia Controller Connected.");
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            south.SetButtonControl(Controller.buttonSouth, "A");
            north.SetButtonControl(Controller.buttonNorth, "Y");
            east.SetButtonControl(Controller.buttonEast, "B");
            west.SetButtonControl(Controller.buttonWest, "X");
            
            DUp.SetButtonControl(Controller.dpad.up);
            DRight.SetButtonControl(Controller.dpad.right);
            DDown.SetButtonControl(Controller.dpad.down);
            DLeft.SetButtonControl(Controller.dpad.left);
            
        }

        private void Reset()
        {
            south.Reset();
            north.Reset();
            east.Reset();
            west.Reset();
            
            DUp.Reset();
            DRight.Reset();
            DDown.Reset();
            DLeft.Reset();
            
        }
    }
}
