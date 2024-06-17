using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Laser : MonoBehaviour
{
    [SerializeField] private Socket socket;
    [SerializeField] private Color color = new Color(191 / 255, 36 / 255, 0);
    [SerializeField] private float colorIntensity = 4.3f;
    [SerializeField] private float beamColorEnhance = 1;
    [SerializeField] private float maxLength = 100;
    [SerializeField] private float thickness = 9;
    [SerializeField] private float noiseScale = 3.14f;
    [SerializeField] private GameObject startVFX;
    [SerializeField] private GameObject endVFX;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.material.color = color * colorIntensity;
        lineRenderer.material.SetFloat("_LaserThickness", thickness);
        lineRenderer.material.SetFloat("_LaserScale", noiseScale);

        ParticleSystem[] particles = transform.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem p in particles)
        {
            Renderer r = p.GetComponent<Renderer>();
            r.material.SetColor("_EmissionColor", color * (colorIntensity = beamColorEnhance));
        }
    }

    private void Start()
    {
        UpdateEndPosition();
    }
    private void Update()
    {
        if (socket.isEmpty)
        {
            UpdateEndPosition();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void UpdateEndPosition()
    {
        Vector2 startPosition = transform.position;
        float rotatonZ = transform.rotation.eulerAngles.z;
        rotatonZ *= Mathf.Deg2Rad;

        Vector2 direction = new Vector2(Mathf.Cos(rotatonZ), Mathf.Sin(rotatonZ));

        RaycastHit2D hit = Physics2D.Raycast(startPosition, direction.normalized);

        float length = maxLength;
        float laserEndRotation = 180;

        if (hit)
        {
            length = (hit.point - startPosition).magnitude;

            laserEndRotation = Vector2.Angle(direction, hit.normal);
            // Debug.Log(laserEndRotation);
        }

        lineRenderer.SetPosition(1, new Vector2(length, 0));

        Vector2 endPosition = startPosition + length * direction;
        startVFX.transform.position = startPosition;
        endVFX.transform.position = endPosition;
        endVFX.transform.rotation = Quaternion.Euler(0, 0, laserEndRotation);
    }
}
