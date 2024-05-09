using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagement : MonoBehaviour
{
    Vector2 startPos;
    private Rigidbody2D rb;
    [SerializeField] private float respawnTime = 0.5f;
    private TagManagement tagManager;
    public bool godMode;
    private Transform tagPlayer;
    private StatisticsManagement gameStatistics;
    private InputAction pauseAction;
    private GameControl gameControl;
    private bool hasDied = false;
    private SpriteRenderer playerSprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        tagManager = FindObjectOfType<TagManagement>();
        gameStatistics = FindObjectOfType<StatisticsManagement>();
        tagPlayer = transform;
        gameControl = FindObjectOfType<GameControl>();
        pauseAction = new InputAction(binding: "<Keyboard>/escape");
        pauseAction.performed += context => gameControl.OnMenu(context);
    }

    public void Update()
    {
        // provisional - replace for checkbox in game menu
        if (Input.GetKeyDown(KeyCode.G))
        {
            godMode = !godMode;
            GodMode();
        }
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void HandleEnemyCollision(Collider2D collider)
    {
        if (tagManager.IsInTagCategory(collider.gameObject.tag, "Enemies") && !hasDied)
        {
            if (!godMode)
            {
                Die();
            }
            else
            {
                return;
            }
            hasDied = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleEnemyCollision(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        HandleEnemyCollision(collider);
    }

    private void Die()
    {
        gameStatistics.PlayerDied();
        StartCoroutine(Respawn(respawnTime));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GodMode()
    {
        if (godMode)
        {
            tagPlayer.gameObject.tag = "playerGodMode";
            playerSprite.color = new Color(255f, 255f, 0f);
        }
        else
        {
            tagPlayer.gameObject.tag = "playerNormalMode";
            playerSprite.color = new Color(255f, 255f, 255f);
        }
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

    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }
}
