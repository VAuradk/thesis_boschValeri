using UnityEngine;

public class KeyEntrance : MonoBehaviour
{
    [HideInInspector] public bool playerKey = false;
    private TagManagement tagManagement;

    private void Start()
    {
        tagManagement = FindObjectOfType<TagManagement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagManagement.IsInTagCategory(collision.gameObject.tag, "PlayerMode"))
        {
            playerKey = true;
            Destroy(gameObject);
        }
    }
}
