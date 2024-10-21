using UnityEngine.InputSystem.Layouts;
using System.Runtime.InteropServices;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

[StructLayout(LayoutKind.Explicit, Size = 10)]
struct StadiaControllerState : IInputStateTypeInfo
{
    // Because all HID input reports are tagged with the 'HID ' FourCC,
    // this is the format we need to use for this state struct.
    public FourCC format => new FourCC('H', 'I', 'D');

    // HID input reports can start with an 8-bit report ID. It depends on the device
    // whether this is present or not. I don't believe this is present on a Stadia
    // Controller. We don't really need to add the field, but let's do so for the sake of
    // completeness. This can also help with debugging.
    [FieldOffset(0)] public byte reportId;

    // The InputControl annotations here probably look a little scary, but what we do
    // here is relatively straightforward. The fields we add we annotate with
    // [FieldOffset] to force them to the right location, and then we add InputControl
    // to attach controls to the fields. Each InputControl attribute can only do one of
    // two things: either it adds a new control or it modifies an existing control.
    // Given that our layout is based on Gamepad, almost all the controls here are
    // inherited from Gamepad, and we just modify settings on them.

    // The DPad inputs are the same as a PS DuelShock controller.
    [InputControl(name = "dpad", format = "BIT", layout = "Dpad", sizeInBits = 4, defaultState = 8)]
    [InputControl(name = "dpad/up", format = "BIT", layout = "DiscreteButton", parameters = "minValue=7,maxValue=1,nullValue=8,wrapAtValue=7", bit = 0, sizeInBits = 4)]
    [InputControl(name = "dpad/right", format = "BIT", layout = "DiscreteButton", parameters = "minValue=1,maxValue=3", bit = 0, sizeInBits = 4)]
    [InputControl(name = "dpad/down", format = "BIT", layout = "DiscreteButton", parameters = "minValue=3,maxValue=5", bit = 0, sizeInBits = 4)]
    [InputControl(name = "dpad/left", format = "BIT", layout = "DiscreteButton", parameters = "minValue=5, maxValue=7", bit = 0, sizeInBits = 4)]
    [InputControl(name = "dpad/x", format = "BIT", layout = "DpadAxis")]
    [InputControl(name = "dpad/y", format = "BIT", layout = "DpadAxis")]

    // The next 4 bits are empty?

    [FieldOffset(1)] public byte buttons1;



    // These are non-regular to gampads and thus are optional
    [InputControl(name = "captureButton", layout = "Button", displayName = "Capture", offset = 2, bit = 0)]
    [InputControl(name = "googleButton", layout = "Button", displayName = "Assistant", offset = 2, bit = 1)]
    [InputControl(name = "leftTriggerButton", layout = "Button", bit = 2)]
    [InputControl(name = "rightTriggerButton", layout = "Button", bit = 3)]
    // The Stadia Button
    [InputControl(name = "systemButton", displayName = "Home", layout = "Button", bit = 4)]


    [InputControl(name = "start", displayName = "Menu", offset = 2, bit = 5)]
    [InputControl(name = "select", displayName = "Options", offset = 2, bit = 6)]
    [InputControl(name = "rightStickPress", bit = 7)]
    [FieldOffset(2)] public byte buttons2;

    [InputControl(name = "leftStickPress", bit = 0)]
    [InputControl(name = "rightShoulder", bit = 1)]
    [InputControl(name = "leftShoulder", bit = 2)]
    [InputControl(name = "buttonNorth", displayName = "Y", bit = 3)]
    [InputControl(name = "buttonWest", displayName = "X", bit = 4)]
    [InputControl(name = "buttonEast", displayName = "B", bit = 5)]
    [InputControl(name = "buttonSouth", displayName = "A", bit = 6)]
    // Unused Bit?
    [FieldOffset(3)] public byte buttons3;



    // Takes up byte 4
    [InputControl(name = "leftStick", layout = "Stick", format = "VC2B")]
    [InputControl(name = "leftStick/x", format = "BYTE",
        parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
    [InputControl(name = "leftStick/left", format = "BYTE",
        parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp,clampMin=0,clampMax=0.5,invert")]
    [InputControl(name = "leftStick/right", format = "BYTE",
        parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp,clampMin=0.5,clampMax=1")]

    // Takes up byte 5
    [InputControl(name = "leftStick/y", offset = 1, format = "BYTE",
        parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
    [InputControl(name = "leftStick/up", offset = 1, format = "BYTE",
        parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp,clampMin=0,clampMax=0.5,invert")]
    [InputControl(name = "leftStick/down", offset = 1, format = "BYTE",
        parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp,clampMin=0.5,clampMax=1,invert=false")]
    [FieldOffset(4)] public byte leftStickX;
    [FieldOffset(5)] public byte leftStickY;



    // Takes up byte 6
    [InputControl(name = "rightStick", layout = "Stick", format = "VC2B")]
    [InputControl(name = "rightStick/x", format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
    [InputControl(name = "rightStick/left", format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp,clampMin=0,clampMax=0.5,invert")]
    [InputControl(name = "rightStick/right", format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp,clampMin=0.5,clampMax=1")]

    // Takes up byte 7
    [InputControl(name = "rightStick/y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
    [InputControl(name = "rightStick/up", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp,clampMin=0,clampMax=0.5,invert")]
    [InputControl(name = "rightStick/down", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp,clampMin=0.5,clampMax=1,invert=false")]
    [FieldOffset(6)] public byte rightStickX;
    [FieldOffset(7)] public byte rightStickY;


    // Not present on every controller?
    // Takes up byte 8
    [InputControl(name = "leftTrigger", format = "BYTE")]
    [FieldOffset(8)] public byte leftTrigger;



    // Takes up byte 9
    [InputControl(name = "rightTrigger", format = "BYTE")]
    [FieldOffset(9)] public byte rightTrigger;
}