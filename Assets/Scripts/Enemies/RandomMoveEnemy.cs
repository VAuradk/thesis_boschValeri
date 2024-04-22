using System.Collections;
using UnityEngine;

public class RandomMoveEnemy : EnemyManagement
{
    [SerializeField] private float changeDirectionInterval = 2f;

    private Vector2 moveDirection;

    public override void Start()
    {
        base.Start();
        StartCoroutine(ChangeDirection());
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            enemyRB.velocity = moveDirection * enemySpeed;
        }

    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            moveDirection = Random.insideUnitCircle.normalized;
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }
}
