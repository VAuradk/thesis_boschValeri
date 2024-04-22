using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    public GameObject bullet;
    public Transform bulletTransform;
    private bool canFire = true;

    [SerializeField]
    private float fireRate = 3f;
    private float timer;
    private PlayerInput input = null;

    [SerializeField]
    private float bulletLiftime = 6f;

    void Start()
    {
        input = new PlayerInput();
        mainCam = Camera.main;
        input.Player.Shot.performed += OnShot;
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                canFire = true;
                timer = 0;
            }
        }
    }

    public void OnShot(InputAction.CallbackContext context)
    {
        if (canFire)
        {
            var bulletPref = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            canFire = false;

            Destroy(bulletPref, bulletLiftime);
        }
    }
}
