using UnityEngine;

public class KeyEntrance : MonoBehaviour
{
    [HideInInspector] public bool playerKey = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.CompareTag("godMode"))
        {
            playerKey = true;
            Destroy(gameObject);
        }
    }
}
