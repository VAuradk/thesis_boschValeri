using System.Collections;
using UnityEngine;

public class InvisibleEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float invisibilityDuration = 2f;
    [SerializeField] private float invisibilityInterval = 5f;
    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;
    private SpriteRenderer spriteRenderer;
    private bool isVisible = true;
    private Coroutine visibilityCoroutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        visibilityCoroutine = StartCoroutine(ToggleVisibility());
    }

    private void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    private IEnumerator ToggleVisibility()
    {
        yield return new WaitForSeconds(invisibilityInterval);

        while (true)
        {
            isVisible = !isVisible;
            spriteRenderer.enabled = isVisible;

            if (isVisible)
            {
                yield return new WaitForSeconds(invisibilityDuration);
            }
            else
            {
                yield return new WaitForSeconds(invisibilityInterval - invisibilityDuration);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = true;
            if (visibilityCoroutine != null)
            {
                StopCoroutine(visibilityCoroutine);
            }
            visibilityCoroutine = StartCoroutine(ToggleVisibility());
        }
    }
}
