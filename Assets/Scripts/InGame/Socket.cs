using UnityEngine;

public class Socket : MonoBehaviour
{
    public bool greenEnemy = false;
    public bool yellowEnemy = false;
    public bool blueEnemy = false;
    public bool orangeEnemy = false;

    [HideInInspector] public bool isEmpty = true;
    private Vector2 socketPosition;
    [SerializeField] private float threshold = 0.1f;

    private void Start()
    {
        socketPosition = (Vector2)transform.position;
        IdentifyActiveEnemy();
    }

    private void Update()
    {
        if (!isEmpty)
        {
            return;
        }

        GameObject[] allGameObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allGameObjects)
        {
            if (IsActiveEnemy(obj.tag))
            {
                if (Vector2.Distance(socketPosition, obj.transform.position) < threshold)
                {
                    isEmpty = false;
                    Rigidbody2D enemyRigidbody = obj.GetComponent<Rigidbody2D>();
                    enemyRigidbody.simulated = false;
                    obj.transform.position = socketPosition;
                    SpriteRenderer enemyColor = obj.GetComponent<SpriteRenderer>();
                    enemyColor.color = new Color(255f, 255f, 255f, 0.5f);
                }
            }
        }
    }

    void IdentifyActiveEnemy()
    {
        if (greenEnemy)
        {
            Debug.Log("Green enemy is active.");
        }
        else if (yellowEnemy)
        {
            Debug.Log("Yellow enemy is active.");
        }
        else if (blueEnemy)
        {
            Debug.Log("Blue enemy is active.");
        }
        else if (orangeEnemy)
        {
            Debug.Log("Orange enemy is active.");
        }
        else
        {
            Debug.LogWarning("No enemy is active.");
        }
    }

    bool IsActiveEnemy(string tag)
    {
        if (greenEnemy && tag == "enemyBasic")
        {
            return true;
        }
        if (yellowEnemy && tag == "enemyChase")
        {
            return true;
        }
        if (blueEnemy && tag == "enemyInvisible")
        {
            return true;
        }
        if (orangeEnemy && tag == "enemyRandom")
        {
            return true;
        }
        return false;
    }
}
