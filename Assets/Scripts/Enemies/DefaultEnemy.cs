
using UnityEngine;

public class DefaultEnemy : EnemyManagement
{
    [SerializeField] private float decelerationRate = 0.5f;

    private void FixedUpdate()
    {
        if (isMoving)
        {
            enemyRB.velocity -= enemyRB.velocity.normalized * decelerationRate * Time.fixedDeltaTime;
            if (enemyRB.velocity.magnitude < 0.1f)
            {
                enemyRB.velocity = Vector2.zero;
                enemyRB.angularVelocity = 0f;
                isMoving = false;
            }
        }
    }
}
