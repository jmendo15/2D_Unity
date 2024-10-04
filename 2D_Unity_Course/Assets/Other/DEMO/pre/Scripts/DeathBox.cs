using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class DeathBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with this death box is the player
        if (other.CompareTag("Player"))
        {
            RestartLevel();
        }
    }

    // Method to restart the current level
    void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
