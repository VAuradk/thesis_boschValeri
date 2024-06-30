using UnityEngine;

public class ChaseEnemy : EnemyManagement
{
    [HideInInspector] public Transform target;
    private Vector2 moveDirection;
    [SerializeField] private float distanceThreshold;
    private float distance;
    private bool isMovingTowardsTarget = false;

    public override void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("playerNormalMode").transform;
    }

    public virtual void Update()
    {
        if (target)
        {
            distance = Vector2.Distance(transform.position, target.position);
            Vector2 direction = target.position - transform.position;
            direction.Normalize();

            if (distance < distanceThreshold)
            {
                isMovingTowardsTarget = true;
            }

            if (isMovingTowardsTarget)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, target.position, enemySpeed * Time.deltaTime);
            }
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

    public override void OnCollisionStay2D(Collision2D collision)
    {
        // Avoid father behavior that creates unwanted outcomes
    }
}
