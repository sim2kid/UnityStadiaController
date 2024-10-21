using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Controls;

[InputControlLayout(stateType = typeof(StadiaControllerState))]
#if UNITY_EDITOR
[InitializeOnLoad] // Make sure static constructor is called during startup.
#endif
public class StadiaController : Gamepad
{
    static StadiaController()
    {
        // Match device via Name and Manufacturer
        InputSystem.RegisterLayout<StadiaController>(
            "Stadia Controller",
            new InputDeviceMatcher()
                .WithInterface("HID")
                .WithManufacturer("Google Inc.")
                .WithProduct("Stadia Controller"));

        // OR match device via VendorID and Product ID
        InputSystem.RegisterLayout<StadiaController>(
            "Stadia Controller",
            new InputDeviceMatcher()
                .WithInterface("HID")
                .WithCapability("vendorId", 0x18D1) // Google Inc.
                .WithCapability("productId", 0x9400)); // Stadia Controller *
    }

    // In the Player, to trigger the calling of the static constructor,
    // create an empty method annotated with RuntimeInitializeOnLoadMethod.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    { }
    
    public ButtonControl captureButton { get; protected set; }
    public ButtonControl googleButton { get; protected set; }

    protected override void FinishSetup()
    {
        captureButton = GetChildControl<ButtonControl>("captureButton");
        googleButton = GetChildControl<ButtonControl>("googleButton");

        base.FinishSetup();
    }
}