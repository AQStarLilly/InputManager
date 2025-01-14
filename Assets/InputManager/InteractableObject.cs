using UnityEngine;
using System.Collections;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public string interactionMessage = "You interacted with the object!"; // Customizable message
    public TextMeshProUGUI uiText; // Reference to the TextMeshPro component on the Canvas

    private bool _playerInRange = false; // Track if the player is in range
    private float _messageDisplayTime = 2f; // How long to display the message
    private Coroutine _messageCoroutine;

    private void OnEnable()
    {
        Actions.OnInteract += HandleInteract;
    }

    private void OnDisable()
    {
        Actions.OnInteract -= HandleInteract;
    }

    private void HandleInteract()
    {
        if (_playerInRange)
        {
            Debug.Log($"Interacted with {gameObject.name}");

            // Show the interaction message
            if (uiText != null)
            {
                if (_messageCoroutine != null)
                {
                    StopCoroutine(_messageCoroutine); // Stop any existing coroutine
                }
                _messageCoroutine = StartCoroutine(DisplayMessage(interactionMessage));
            }

            // Add additional interaction logic here (e.g., open door, pick up item)
        }
    }

    private IEnumerator DisplayMessage(string message)
    {
        uiText.text = message; // Set the message
        uiText.gameObject.SetActive(true); // Ensure the text is visible

        yield return new WaitForSeconds(_messageDisplayTime); // Wait for the display time

        uiText.gameObject.SetActive(false); // Hide the text
        uiText.text = ""; // Clear the message
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = true;
            Debug.Log($"Player entered interaction range of {gameObject.name}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = false;
            Debug.Log($"Player left interaction range of {gameObject.name}");
        }
    }
}