using System.Linq;
using sim2kid.Package.StadiaInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tests
{
    public class StadiaInputTests : MonoBehaviour
    {
        public StadiaController Controller { get; private set; }
        
        void Update()
        {
            FindController();
        }

        private void FindController()
        {
            if (Controller != null)
            {
                if (Controller.added == false) Controller = null;
                return;
            }
            var controller = InputSystem.devices.FirstOrDefault(device => device is StadiaController);
            if (controller is not StadiaController stadiaController) return;
            Controller = stadiaController;
            Debug.Log($"Stadia controller found: {Controller.name}");
        }
    }
}
