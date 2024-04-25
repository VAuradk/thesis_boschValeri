using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Socket socket;
    private SpriteRenderer render;
    private PolygonCollider2D laserCollider;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        laserCollider = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if (socket.isEmpty == false)
        {
            render.enabled = false;
            laserCollider.enabled = false;
        }
    }
}
