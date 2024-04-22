using UnityEngine;

public class PortalTP : MonoBehaviour
{
    [SerializeField] private KeyEntrance key;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (key.playerKey == true)
            {
                SceneController.instance.NextLevel();
            }
        }
    }
}
