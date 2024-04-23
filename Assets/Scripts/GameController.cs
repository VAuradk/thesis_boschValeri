using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 startPos;
    private Rigidbody2D rb;
    [SerializeField] private float respawnTime = 0.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gameObject.tag != "godMode")
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("EnemyFire") && gameObject.tag != "godMode")
        {
            Die();
        }
    }

    private void Die()
    {
        StartCoroutine(Respawn(respawnTime));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator Respawn(float duration)
    {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.localScale = Vector3.zero;
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        transform.eulerAngles = Vector3.zero;
        transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.5);
        rb.simulated = true;
    }
}
