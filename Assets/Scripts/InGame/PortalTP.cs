using UnityEngine;

public class PortalTP : MonoBehaviour
{
    [SerializeField] private KeyEntrance key;
    private TagManagement tagManager;

    private void Awake()
    {
        tagManager = FindObjectOfType<TagManagement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagManager.IsInTagCategory(collision.gameObject.tag, "PlayerMode"))
        {
            if (key.playerKey == true)
            {
                SceneManagement.instance.NextLevel();
            }
        }
    }
}
