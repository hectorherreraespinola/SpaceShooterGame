using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    [Header("Missile Prefab")]
    public GameObject missilePrefab1;
    public GameObject missilePrefab2;
    public Transform missileSpawnPoint1;
    public Transform missileSpawnPoint2;
    public float destroyTime = 2.0f;

    public Transform muzzleSpawnPoint1;
    public Transform muzzleSpawnPoint2;

    [Header("Screen Bounds")]
    [Tooltip("Margin (world units) kept between the ship and the screen edge.")]
    public float screenPadding = 0.5f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void Update()
    {
        PlayerMovement();
        PlayerShoot();
    }

    void PlayerMovement()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xPos * speed * Time.deltaTime, yPos * speed * Time.deltaTime, 0);
        transform.Translate(movement);
        ClampToScreen();
    }

    void ClampToScreen()
    {
        if (cam == null || !cam.orthographic) return;

        float halfH = cam.orthographicSize;
        float halfW = halfH * cam.aspect;
        Vector3 c = cam.transform.position;
        Vector3 p = transform.position;
        p.x = Mathf.Clamp(p.x, c.x - halfW + screenPadding, c.x + halfW - screenPadding);
        p.y = Mathf.Clamp(p.y, c.y - halfH + screenPadding, c.y + halfH - screenPadding);
        transform.position = p;
    }

    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantiateMissile(missilePrefab1, missileSpawnPoint1);
            InstantiateMissile(missilePrefab2, missileSpawnPoint2);
            // One flash per cannon per shot (previously spawned twice per shot).
            SpawnMuzzleFlash();
        }
    }

    void InstantiateMissile(GameObject missilePrefab, Transform missileSpawnPoint)
    {
        if (missilePrefab == null || missileSpawnPoint == null) return;

        GameObject missile = Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation);
        Destroy(missile, destroyTime);
    }

    void SpawnMuzzleFlash()
    {
        InstantiateAndDestroyMuzzleFlash(muzzleSpawnPoint1);
        InstantiateAndDestroyMuzzleFlash(muzzleSpawnPoint2);
    }

    void InstantiateAndDestroyMuzzleFlash(Transform muzzleSpawnPoint)
    {
        if (muzzleSpawnPoint == null || GameManager.instance == null || GameManager.instance.muzzleFlash == null) return;

        GameObject muzzle = Instantiate(GameManager.instance.muzzleFlash, muzzleSpawnPoint);
        muzzle.transform.SetParent(null);
        Destroy(muzzle, destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.IsEnemy(collision.gameObject)) return;

        if (GameManager.instance != null)
        {
            if (GameManager.instance.explosion != null)
            {
                GameObject fx = Instantiate(GameManager.instance.explosion, transform.position, Quaternion.identity);
                Destroy(fx, 2.0f);
            }
            GameManager.instance.GameOver();
        }
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
