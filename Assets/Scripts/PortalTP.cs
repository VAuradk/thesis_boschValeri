using UnityEngine;

public class PortalTP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneController.instance.NextLevel();
        }
    }
}
