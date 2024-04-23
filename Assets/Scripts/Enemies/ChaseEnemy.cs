
using UnityEngine;

public class ChaseEnemy : EnemyManagement
{
    private Transform target;
    private Vector2 moveDirection;

    public override void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("playerNormalMode").transform;
    }

    public virtual void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            enemyRB.rotation = angle;
            moveDirection = direction;
        }
    }

    public virtual void FixedUpdate()
    {
        if (isMoving)
        {
            if (target)
            {
                enemyRB.velocity = new Vector2(moveDirection.x, moveDirection.y) * enemySpeed;
            }
        }
    }
}
