using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] int life = 3;
    private Rigidbody2D rb;
    private Vector2 direction;
    private TagManagement tagManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction)
    {
        this.direction = direction;
        rb.velocity = this.direction * speed;
        tagManager = FindObjectOfType<TagManagement>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (tagManager.IsInTagCategory(collision.gameObject.tag, "Collisions"))
        {
            life--;
            if (life < 0)
            {
                Destroy(gameObject);
                return;
            }

            var firstContact = collision.contacts[0];
            Vector2 newVelocity = Vector2.Reflect(direction.normalized, firstContact.normal);
            Shoot(newVelocity.normalized);
        }

        if (tagManager.IsInTagCategory(collision.gameObject.tag, "Enemies"))
        {
            Destroy(gameObject);
            return;
        }
    }
}
