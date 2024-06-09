using System.Collections;
using UnityEngine;

public class InvisibleEnemy : ChaseEnemy
{
    [SerializeField] private float invisibilityDuration = 2f;
    [SerializeField] private float invisibilityInterval = 5f;

    private SpriteRenderer spriteRenderer;
    private Material material;
    private float fade = 1f;
    private Coroutine visibilityCoroutine;

    public override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
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
            // Fade out
            yield return StartCoroutine(FadeTo(0f, 1f));
            yield return new WaitForSeconds(invisibilityDuration);

            // Fade in
            yield return StartCoroutine(FadeTo(1f, 1f));
            yield return new WaitForSeconds(invisibilityInterval - invisibilityDuration);
        }
    }

    private IEnumerator FadeTo(float targetAlpha, float fadeTime)
    {
        float startAlpha = fade;
        float elapsedTime = 0f;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            fade = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeTime);
            material.SetFloat("_Fade", fade);
            yield return null;
        }

        fade = targetAlpha;
        material.SetFloat("_Fade", fade);
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (tagManager.IsInTagCategory(collision.gameObject.tag, "PlayerMode"))
        {
            ResetVisibilityCoroutine();
            fade = 1f;
            material.SetFloat("_Fade", fade);
            visibilityCoroutine = StartCoroutine(ToggleVisibility());
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            ResetVisibilityCoroutine();
            StartCoroutine(FadeTo(1f, 0.1f));
            visibilityCoroutine = StartCoroutine(ToggleVisibility());
        }
    }

    private void ResetVisibilityCoroutine()
    {
        if (visibilityCoroutine != null)
        {
            StopCoroutine(visibilityCoroutine);
            visibilityCoroutine = null;
        }
    }
}
