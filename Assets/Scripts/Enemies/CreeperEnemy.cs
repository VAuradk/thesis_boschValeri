using UnityEngine;

public class CreeperEnemy : EnemyManagement
{
    public GameObject squarePrefab;
    public int numberOfSquares = 5;
    public float squareLifetime = 2f;
    public float squareSpeed = 5f;

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.collider.CompareTag("Bullet") || collision.collider.CompareTag("Enemy"))
        {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        for (int i = 0; i < numberOfSquares; i++)
        {
            // Instantiate squares with random direction and position
            GameObject square = Instantiate(squarePrefab, transform.position, Quaternion.identity);
            Rigidbody2D squareRb = square.GetComponent<Rigidbody2D>();
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            squareRb.velocity = randomDirection * squareSpeed;
            Destroy(square, squareLifetime);
        }
        
        Destroy(gameObject);
    }
}

