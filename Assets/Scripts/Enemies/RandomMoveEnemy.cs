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

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (!tagManager.IsInTagCategory(collision.gameObject.tag, "PlayerMode"))
        {
            moveDirection = Random.insideUnitCircle.normalized;
        }
    }
}
