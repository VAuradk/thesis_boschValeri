using UnityEngine;

public class CreeperEnemy : EnemyManagement
{

    // public ParticleSystem particles;

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        // Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
