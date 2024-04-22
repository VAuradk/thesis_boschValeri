using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private Camera mainCam;
    public Bullet bulletPrefab;
    public Transform bulletSpawnPos;
    private Transform rotatePoint;

    private void Awake()
    {
        rotatePoint = GetComponent<Transform>();
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
        if (context.phase == InputActionPhase.Started)
        {
            Vector2 direction = GetMouseWorldPosition() - (Vector2)bulletSpawnPos.position;
            Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity);
            bullet.Shoot(direction.normalized);
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
