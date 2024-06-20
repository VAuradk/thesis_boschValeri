using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private Camera mainCam;
    public Bullet bulletPrefab;
    public Transform bulletSpawnPos;
    private Transform rotatePoint;
    private AudioManagement audioManagement;
    [SerializeField] private float fireRate = 0.5f;
    private float nextFireTime = 0f;

    private void Awake()
    {
        rotatePoint = GetComponent<Transform>();
        audioManagement = GameObject.FindGameObjectWithTag("AudioControl").GetComponent<AudioManagement>();
    }

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        RotateTowardsMouse();
    }

    public void OnShot(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && Time.time >= nextFireTime && !LayoutManagement.instance.IsGamePaused)
        {
            Vector2 direction = GetMouseWorldPosition() - (Vector2)bulletSpawnPos.position;
            Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity);
            bullet.Shoot(direction.normalized);
            audioManagement.PlaySFX(audioManagement.playerShot);
            nextFireTime = Time.time + fireRate;
        }
    }

    private void RotateTowardsMouse()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 direction = mousePosition - rotatePoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotatePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private Vector2 GetMouseWorldPosition()
    {
        return mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
