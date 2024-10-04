using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public string sceneToLoad;            // Name of the scene to load when the player presses [E]
    public GameObject promptTextObject;   // UI Text object that shows the prompt (e.g., "[E] Exit")

    private bool isPlayerInRange = false; // Is the player in range of the door?

    void Start()
    {
        // Ensure the prompt text is hidden at the start
        promptTextObject.SetActive(false);
    }

    void Update()
    {
        // Check if the player is in range and presses [E]
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            promptTextObject.SetActive(true); // Show the prompt
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exits the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            promptTextObject.SetActive(false); // Hide the prompt
        }
    }
}
