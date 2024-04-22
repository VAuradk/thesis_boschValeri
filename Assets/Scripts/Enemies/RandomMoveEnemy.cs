using System.Collections;
using UnityEngine;

public class RandomMoveEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float changeDirectionInterval = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(ChangeDirection());
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
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
