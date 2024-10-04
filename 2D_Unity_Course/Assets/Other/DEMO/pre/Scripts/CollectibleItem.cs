using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public int scoreValue = 1; // Value to add to the player's score when collected

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with this item is the player
        if (other.CompareTag("Player"))
        {
            // Optionally, add to the player's score or other logic here

            // Destroy the collectible item to make it disappear
            this.gameObject.SetActive(false);
        }
    }
}
