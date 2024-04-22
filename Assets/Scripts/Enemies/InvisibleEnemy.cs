using System.Collections;
using UnityEngine;

public class InvisibleEnemy : ChaseEnemy
{
    [SerializeField] private float invisibilityDuration = 2f;
    [SerializeField] private float invisibilityInterval = 5f;

    private SpriteRenderer spriteRenderer;
    private bool isVisible = true;
    private Coroutine visibilityCoroutine;

    public override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Start()
    {
        base.Start();
        visibilityCoroutine = StartCoroutine(ToggleVisibility());
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

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
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
