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
        private ButtonPressed south; 
        
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
        }

        private void Reset()
        {
            south.Reset();
        }
    }
}
