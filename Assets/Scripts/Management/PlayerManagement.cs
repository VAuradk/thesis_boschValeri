using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerManagement : MonoBehaviour
{
    [SerializeField] private float respawnTime;
    private Rigidbody2D rb;
    private Transform tagPlayer;
    private TagManagement tagManager;
    private StatisticsManagement gameStatistics;
    private AudioManagement audioManagement;
    private SceneManagement sceneManagement;
    private InputAction pauseAction;
    private LayoutManagement layoutManagement;
    private SpriteRenderer playerSprite;
    private bool hasDied = false;
    public bool godMode;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        tagManager = FindObjectOfType<TagManagement>();
        gameStatistics = FindObjectOfType<StatisticsManagement>();
        sceneManagement = FindAnyObjectByType<SceneManagement>();
        audioManagement = GameObject.FindGameObjectWithTag("AudioControl").GetComponent<AudioManagement>();
        tagPlayer = transform;
        layoutManagement = FindObjectOfType<LayoutManagement>();
        pauseAction = new InputAction(binding: "<Keyboard>/escape");
        pauseAction.performed += context => layoutManagement.OnMenu(context);
    }

    private void Start()
    {
        rb.freezeRotation = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            godMode = !godMode;
            GodMode();
        }
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

    public void Die()
    {
        gameStatistics.PlayerDied();
        audioManagement.PlaySFX(audioManagement.playerKill);
        StartCoroutine(Respawn(respawnTime));
        sceneManagement.Restart();
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
        yield return new WaitForSeconds(duration);
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
