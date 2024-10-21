using System.Linq;
using sim2kid.Package.StadiaInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tests
{
    public class StadiaInputTests : MonoBehaviour
    {
        private StadiaController _controller;
        
        void Update()
        {
            FindController();
        }

        private void FindController()
        {
            if (_controller != null) return;
            var controller = InputSystem.devices.FirstOrDefault(device => device is StadiaController);
            if (controller is not StadiaController stadiaController) return;
            _controller = stadiaController;
            Debug.Log($"Stadia controller found: {_controller.name}");
        }
    }
}
