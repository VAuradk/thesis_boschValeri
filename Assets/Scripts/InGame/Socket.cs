using UnityEngine;

public class Socket : MonoBehaviour
{
    [HideInInspector] public bool isEmpty = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemyBasic"))
        {
            Rigidbody2D idk = collision.GetComponentInChildren<Rigidbody2D>();
            idk.simulated = false;
            isEmpty = false;
            // Debug.Log(isEmpty);
        }
    }
}
