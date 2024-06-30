using UnityEngine;
public class EnemyBullet : MonoBehaviour
{
    [HideInInspector] public TagManagement tagManager;

    private void Awake()
    {
        tagManager = FindObjectOfType<TagManagement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagManager.IsInTagCategory(collision.gameObject.tag, "Collisions"))
        {
            Destroy(gameObject);
        }
    }
}
