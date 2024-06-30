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

                    if (blueEnemy || yellowEnemy)
                    {
                        ChaseEnemy chaseEnemy = obj.GetComponent<ChaseEnemy>();
                        chaseEnemy.target = null;

                        if (blueEnemy)
                        {
                            InvisibleEnemy invisibleEnemy = obj.GetComponent<InvisibleEnemy>();
                            invisibleEnemy.invisibilityInterval = 9999f;
                        }
                    }

                    Rigidbody2D enemyRigidbody = obj.GetComponent<Rigidbody2D>();
                    enemyRigidbody.simulated = false;
                    obj.transform.position = socketPosition;
                    SpriteRenderer enemyColor = obj.GetComponent<SpriteRenderer>();
                    enemyColor.color = new Color(255f, 255f, 255f, 0.5f);
                }
            }
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
