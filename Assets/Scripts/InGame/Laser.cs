using UnityEngine;
using System.Collections.Generic;
public class Laser : MonoBehaviour
{
    [SerializeField] private Socket socket;
    [SerializeField] private Color color = new Color(191 / 255, 36 / 255, 0);
    [SerializeField] private Color endColor = new Color(255, 255, 255);
    [SerializeField] private float colorIntensity = 4.3f;
    [SerializeField] private float beamColorEnhance = 1;
    [SerializeField] private float maxLength = 100;
    [SerializeField] private float thickness = 9;
    [SerializeField] private float noiseScale = 3.14f;
    [SerializeField] private GameObject startVFX;
    [SerializeField] private GameObject endVFX;
    [SerializeField] private float duration = 1.5f;
    private PlayerManagement playerManagement;
    private Collider2D c;
    public LayerMask ingoreThis;
    private LineRenderer lineRenderer;
    private float elapsedTime = 0f;
    private Color currentColor;
    private List<ParticleSystem> particleSystems = new List<ParticleSystem>();

    private void Awake()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.material.color = color * colorIntensity;
        lineRenderer.material.SetFloat("_LaserThickness", thickness);
        lineRenderer.material.SetFloat("_LaserScale", noiseScale);

        ParticleSystem[] particles = transform.GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem p in particles)
        {
            particleSystems.Add(p);
            var mainModule = p.main;
            mainModule.startColor = new ParticleSystem.MinMaxGradient(color * colorIntensity);
            Renderer r = p.GetComponent<Renderer>();
            r.material.SetColor("_EmissionColor", color * (colorIntensity * beamColorEnhance));
        }

        currentColor = color;
        c = GetComponent<Collider2D>();
        playerManagement = FindAnyObjectByType<PlayerManagement>();
    }

    private void Start()
    {
        UpdateEndPosition();
    }

    private void Update()
    {
        if (socket.isEmpty == false)
        {
            UpdateEndPosition();

            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            currentColor = Color.Lerp(color, endColor, t);
            lineRenderer.material.color = currentColor * colorIntensity;

            foreach (ParticleSystem ps in particleSystems)
            {
                var mainModule = ps.main;
                mainModule.startColor = new ParticleSystem.MinMaxGradient(currentColor * colorIntensity);

                Renderer r = ps.GetComponent<Renderer>();

                if (r != null && r.material.HasProperty("_EmissionColor"))
                {
                    r.material.SetColor("_EmissionColor", currentColor * (colorIntensity * beamColorEnhance));
                }
            }

            c.enabled = false;
        }
    }

    private void UpdateEndPosition()
    {
        Vector2 startPosition = transform.position;
        float rotatonZ = transform.rotation.eulerAngles.z;
        rotatonZ *= Mathf.Deg2Rad;

        Vector2 direction = new Vector2(Mathf.Cos(rotatonZ), Mathf.Sin(rotatonZ));

        float length = maxLength;
        float laserEndRotation = 180;

        RaycastHit2D hit = Physics2D.Raycast(startPosition, direction.normalized, length, ~ingoreThis);

        if (hit)
        {
            length = (hit.point - startPosition).magnitude;
            laserEndRotation = Vector2.Angle(direction, hit.normal);
        }

        lineRenderer.SetPosition(1, new Vector2(length, 0));
        Vector2 endPosition = startPosition + length * direction;
        startVFX.transform.position = startPosition;
        endVFX.transform.position = endPosition;
        endVFX.transform.rotation = Quaternion.Euler(0, 0, laserEndRotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("playerNormalMode") && socket.isEmpty)
        {
            playerManagement.Die();
        }

        if (collision.gameObject.CompareTag("Bullet") && socket.isEmpty)
        {
            Destroy(collision.gameObject);
        }
    }
}
