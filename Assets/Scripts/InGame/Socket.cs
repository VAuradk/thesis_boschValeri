using UnityEngine;

public class Socket : MonoBehaviour
{
    [HideInInspector] public bool isEmpty = true;
    private Vector2 socketPosition;
    [SerializeField] private float threshold = 0.1f;

    private void Start()
    {
        socketPosition = transform.position;
    }

    private void Update()
    {
        if (!isEmpty)
        {
            return;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemyBasic");

        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(socketPosition, enemy.transform.position) < threshold)
            {
                isEmpty = false;
                Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
                enemyRigidbody.simulated = false;
                enemy.transform.position = socketPosition;
                SpriteRenderer enemyColor = enemy.GetComponent<SpriteRenderer>();
                enemyColor.color = new Color(255f, 255f, 255f, 0.5f);
            }
        }
    }
}
