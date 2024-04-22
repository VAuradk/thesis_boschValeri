using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;

    [Header("Forces")]
    [SerializeField] private float initialForce = 10f;
    // [SerializeField] private float initialBounceForce = 5f;

    // [Header("Bounces")]
    // [SerializeField] private int maxBounces = 3;
    // [SerializeField] private float bounceForceDecay = 0.8f;
    // private float currentBounceForce;
    // private int currentBounces = 0;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * initialForce;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
        // currentBounceForce = initialBounceForce;
    }

    void Update() { }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        // if (collision.gameObject.CompareTag("Wall") && currentBounces < maxBounces)
        // {
        //     Vector2 reflection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
        //     rb.velocity = reflection.normalized * currentBounceForce;

        //     if (currentBounces > 0)
        //     {
        //         currentBounceForce *= bounceForceDecay;
        //     }
        //     currentBounces++;
        // }

        // else if (!collision.gameObject.CompareTag("Wall") && !collision.gameObject.CompareTag("Player") || currentBounces >= maxBounces)
        // {
        //     Destroy(gameObject);
        // }
    }
}
