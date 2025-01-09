using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Space key was pressed.");
        }

        if (Gamepad.current.aButton.wasPressedThisFrame)
        {
            Debug.Log("B button was pressed on gamepad.");
        }
    }
}
