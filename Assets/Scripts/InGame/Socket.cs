using UnityEngine;

public class Socket : MonoBehaviour
{
    [HideInInspector] public bool isEmpty = true;
    Vector2 socketPosition;
    public GameObject socketFiller;

    private void Start()
    {
        socketPosition = gameObject.transform.position;

    }

    private void Update()
    {
        if (Vector2.Distance(socketPosition, socketFiller.GetComponent<Transform>().position) < 0.2)
        {
            socketFiller.GetComponent<Transform>().position = socketPosition;
            isEmpty = false;
            socketFiller.GetComponent<Rigidbody2D>().simulated = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("enemyBasic"))
        {
            Rigidbody2D idk = collision.GetComponentInChildren<Rigidbody2D>();
            idk.simulated = false;
            // Debug.Log(isEmpty);
        }
    }
}
