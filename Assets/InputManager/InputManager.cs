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


    private Action JumpEvent;


    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump Button was pressed!");
            JumpEvent?.Invoke();
        }
    }

    private void OnEnable()
    {

    }

    
}
