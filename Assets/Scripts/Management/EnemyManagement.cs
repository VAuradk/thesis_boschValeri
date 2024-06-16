using UnityEngine;
using System.Collections;

public class EnemyManagement : MonoBehaviour
{
    public float enemySpeed;
    public float timeAFK;
    public float knockbackForce;
    private Vector2 lastBulletDirection;
    [HideInInspector] public Rigidbody2D enemyRB;
    [HideInInspector] public Transform enemyTransform;
    [HideInInspector] public TagManagement tagManager;
    [HideInInspector] public bool isMoving;

    public virtual void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        tagManager = FindObjectOfType<TagManagement>();
        enemyTransform = GetComponent<Transform>();
    }

    public virtual void Start()
    {
        isMoving = true;
        enemyTransform.rotation = Quaternion.identity;
        enemyRB.freezeRotation = true;
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (bullet != null)
            {
                lastBulletDirection = bullet.direction.normalized;
                ApplyKnockback();
                isMoving = false;
                StartCoroutine(WaitTime());
            }
        }
    }

    private void ApplyKnockback()
    {
        enemyRB.velocity = lastBulletDirection * knockbackForce;
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(timeAFK);
        isMoving = true;
    }

    public virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (isMoving && tagManager.IsInTagCategory(collision.gameObject.tag, "Collisions"))
        {
            Vector2 normal = collision.contacts[0].normal;
            lastBulletDirection = (lastBulletDirection - 2 * Vector2.Dot(lastBulletDirection, normal) * normal).normalized;
            ApplyKnockback();
            isMoving = false;
            StartCoroutine(WaitTime());
        }
    }
}
