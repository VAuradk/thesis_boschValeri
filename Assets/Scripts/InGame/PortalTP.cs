using UnityEngine;
public class PortalTP : MonoBehaviour
{
    [SerializeField] private KeyEntrance key;
    private bool isDone = false;
    [SerializeField] private SpriteRenderer materialChildren;
    private SceneManagement sceneManagement;
    private TagManagement tagManagement;
    private Transform rotatePortal;
    private AudioManagement audioManagement;
    float fade = 1f;
    [SerializeField] private float rotationSpeed = 50f;

    private void Awake()
    {
        sceneManagement = FindObjectOfType<SceneManagement>();
        tagManagement = FindObjectOfType<TagManagement>();
        audioManagement = GameObject.FindGameObjectWithTag("AudioControl").GetComponent<AudioManagement>();
    }

    private void Start()
    {
        rotatePortal = GetComponent<Transform>();
    }

    private void Update()
    {
        if (key.playerKey == true)
        {
            rotatePortal.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);

            if (isDone == false)
            {
                Portal();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagManagement.IsInTagCategory(collision.gameObject.tag, "PlayerMode"))
        {
            if (key.playerKey == true)
            {
                audioManagement.PlaySFX(audioManagement.portalEnter);
                sceneManagement.NextScene();
            }
        }
    }

    private void Portal()
    {
        fade -= Time.deltaTime;

        if (fade <= 0f)
        {
            fade = 0f;
            isDone = true;
        }

        materialChildren.material.SetFloat("_Fade", fade);
    }
}
