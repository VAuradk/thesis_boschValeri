using UnityEngine;

public class PortalTP : SceneManagement
{
    [SerializeField] private KeyEntrance key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagManager.IsInTagCategory(collision.gameObject.tag, "PlayerMode"))
        {
            if (key.playerKey == true)
            {
                NextLevel();
            }
        }
    }
}
