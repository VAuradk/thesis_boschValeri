
using UnityEngine;

public class DefaultEnemy : EnemyManagement
{
    [SerializeField] private float decelerationRate = 0.5f;
    // [SerializeField] private float angularDecelerationRate = 1f;

    private void FixedUpdate()
    {
        if (isMoving)
        {
            enemyRB.velocity -= enemyRB.velocity.normalized * decelerationRate * Time.fixedDeltaTime;
            // enemyRB.angularVelocity *= 1 - angularDecelerationRate * Time.fixedDeltaTime;
            // && Mathf.Abs(enemyRB.angularVelocity) < 0.1f
            if (enemyRB.velocity.magnitude < 0.1f)
            {
                enemyRB.velocity = Vector2.zero;
                enemyRB.angularVelocity = 0f;
                isMoving = false;
            }
        }
    }
}
