using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakableWalls : MonoBehaviour
{
    [SerializeField] private int numberHitsTotal = 10;
    private int numberHitsCounter;
    private TilemapRenderer tilemapRenderer;
    private TilemapCollider2D tilemapCollider2D;

    private void Awake()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapCollider2D = GetComponent<TilemapCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            numberHitsCounter++;

            if (numberHitsCounter >= numberHitsTotal)
            {
                Debug.Log(numberHitsCounter);

                tilemapRenderer.enabled = false;
                tilemapCollider2D.enabled = false;
            }
        }
    }

}
