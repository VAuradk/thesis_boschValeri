using UnityEngine;

public class KeyEntrance : SceneManagement
{
    [HideInInspector] public bool playerKey = false;

    private void Awake()
    {
        tagManager = FindObjectOfType<TagManagement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagManager.IsInTagCategory(collision.gameObject.tag, "PlayerMode"))
        {
            playerKey = true;
            Destroy(gameObject);
        }
    }
}
