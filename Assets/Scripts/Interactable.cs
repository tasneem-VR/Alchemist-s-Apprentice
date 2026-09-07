using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using StarterAssets;

public class Interactable : MonoBehaviour
{
    public string interactionMessage = "Press E to interact";
    public GameObject interactionText;
    public GameObject infoPanel;
    public StarterAssetsInputs playerInputs;

    private bool playerNearby = false;

    private void Start()
    {
        interactionText.SetActive(false);
        infoPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            interactionText.SetActive(true);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            interactionText.SetActive(false);
            Debug.Log("Player left the interaction area.");
            
        }
    }

    private void Update()
    {
        if(playerNearby && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    private void Interact()
    {
        Debug.Log("Interacted with the object");
        interactionText.SetActive(false);
        infoPanel.SetActive(true);

        playerInputs.cursorInputForLook = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);

        playerInputs.cursorInputForLook = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerNearby)
        {
            interactionText.SetActive(true);
        }
    }
}
