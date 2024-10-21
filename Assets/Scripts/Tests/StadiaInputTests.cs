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
        
        [SerializeField]
        private ButtonPressed options;
        [SerializeField]
        private ButtonPressed menu;
        
        [SerializeField]
        private ButtonPressed google;
        [SerializeField]
        private ButtonPressed capture;
        
        [SerializeField]
        private ButtonPressed stadia;
        
        [SerializeField]
        private ButtonPressed leftBumper;
        [SerializeField]
        private ButtonPressed leftTrigger;
        [SerializeField]
        private ButtonPressed leftTriggerButton;
        
        [SerializeField]
        private ButtonPressed rightBumper;
        [SerializeField]
        private ButtonPressed rightTrigger;
        [SerializeField]
        private ButtonPressed rightTriggerButton;
        
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
            
            options.SetButtonControl(Controller.selectButton, "***");
            menu.SetButtonControl(Controller.startButton, "===");
            
            google.SetButtonControl(Controller.googleButton, "G");
            capture.SetButtonControl(Controller.captureButton, "C");
            
            stadia.SetButtonControl(null, "S");
            
            leftBumper.SetButtonControl(Controller.leftShoulder, "L1");
            leftTrigger.SetButtonControl(Controller.leftTrigger);
            leftTriggerButton.SetButtonControl(Controller.leftTrigger, "L2");
            
            rightBumper.SetButtonControl(Controller.rightShoulder, "R1");
            rightTrigger.SetButtonControl(Controller.rightTrigger);
            rightTriggerButton.SetButtonControl(Controller.rightTrigger, "R2");
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
            
            google.Reset();
            capture.Reset();
            
            options.Reset();
            menu.Reset();
            
            stadia.Reset();
            
            leftBumper.Reset();
            leftTrigger.Reset();
            leftTriggerButton.Reset();
            
            rightBumper.Reset();
            rightTrigger.Reset();
            rightTriggerButton.Reset();
        }
    }
}
