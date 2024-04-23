using System.Collections;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    public float enemySpeed;
    public float timeAFK;
    [SerializeField] private float knockbackForce = 10f;
    [HideInInspector] public Rigidbody2D enemyRB;
    [HideInInspector] public bool isMoving;
    [HideInInspector] public TagManagement tagManager;

    public virtual void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        tagManager = FindObjectOfType<TagManagement>();
    }

    public virtual void Start()
    {
        isMoving = true;
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            enemyRB.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            isMoving = false;
            StartCoroutine(waitTime());
        }
    }

    private IEnumerator waitTime()
    {
        yield return new WaitForSeconds(timeAFK);
        isMoving = true;
    }
}
