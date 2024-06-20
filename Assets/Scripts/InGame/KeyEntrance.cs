using UnityEngine;

public class KeyEntrance : MonoBehaviour
{
    [HideInInspector] public bool playerKey = false;
    private TagManagement tagManagement;
    private AudioManagement audioManagement;

    private void Start()
    {
        tagManagement = FindObjectOfType<TagManagement>();
        audioManagement = GameObject.FindGameObjectWithTag("AudioControl").GetComponent<AudioManagement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagManagement.IsInTagCategory(collision.gameObject.tag, "PlayerMode"))
        {
            playerKey = true;
            audioManagement.PlaySFX(audioManagement.recolectKey);
            Destroy(gameObject);
        }
    }
}
