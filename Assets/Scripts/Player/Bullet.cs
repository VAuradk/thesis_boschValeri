using System.Collections;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] float life = 3f;
    private Rigidbody2D rb;
    public Vector2 direction;
    private TagManagement tagManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    public void Shoot(Vector2 direction)
    {
        this.direction = direction;
        rb.velocity = this.direction * speed;
        tagManager = FindObjectOfType<TagManagement>();
        StartCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (tagManager.IsInTagCategory(collision.gameObject.tag, "Collisions"))
        {
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
