using UnityEngine;

public class CreeperEnemy : MonoBehaviour
{

    // public ParticleSystem particles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
