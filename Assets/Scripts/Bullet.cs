using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] int life = 3;
    private Rigidbody2D rb;
    private Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction)
    {
        this.direction = direction;
        rb.velocity = this.direction * speed;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
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

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            return;
        }

        // if (collision.gameObject.CompareTag("Player"))
        // {

        //     Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        //     Debug.Log("Player got hit");
        // }
    }
}
