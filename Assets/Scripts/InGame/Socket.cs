using UnityEngine;

public class Socket : MonoBehaviour
{
    [HideInInspector] public bool isEmpty = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemyBasic"))
        {
            // Get the Rigidbody2D component of the enemy
            Rigidbody2D enemyRB = collision.GetComponentInChildren<Rigidbody2D>();

            // Get the position of the socket
            Vector2 socketPosition = transform.position;

            // Set the position of the enemy to match the position of the socket
            enemyRB.position = socketPosition;

            // Disable physics simulation for the enemy
            enemyRB.simulated = false;

            // Update the isEmpty flag
            isEmpty = false;

            // Debug.Log(isEmpty);
        }
    }
}
