using UnityEngine;

public class KeyEntrance : MonoBehaviour
{
    [HideInInspector] public bool playerKey = false;
    private TagManagement tagManager;

    private void Awake()
    {
        tagManager = FindObjectOfType<TagManagement>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagManager.IsInTagCategory(collision.gameObject.tag, "PlayerMode"))
        {
            playerKey = true;
            Destroy(gameObject);
        }
    }
}
