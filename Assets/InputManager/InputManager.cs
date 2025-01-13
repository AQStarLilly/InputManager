using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IGameplayActions
{
    public GameInput gameInput;
  
    void Start()
    {        
        gameInput = new GameInput();

        gameInput.Gameplay.Enable();

        gameInput.Gameplay.SetCallbacks(this);
    }





    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump Button was pressed!");
            
        }
        //started
        if (context.started)
        {
            Debug.Log("Jump has Started.");
        }
        //cancelled
        if (context.canceled)
        {
            Debug.Log("Jump has been Cancelled.");
        }
    }
}
