using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 1.0f;
    public float zigZagFrequency = 2.0f; // Frequency of the zig-zag movement
    public float zigZagMagnitude = 1.0f; // Magnitude of the zig-zag movement
    public float chaseSpeed = 1.5f;      // Horizontal speed used by Enemy3 to follow the player

    private Transform player;

    void Awake()
    {
        // The prefabs use a dynamic Rigidbody2D with gravity, which made enemies
        // free-fall and ignore enemySpeed. Movement is driven by this script instead.
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }
    }

    void Start()
    {
        PlayerController pc = FindObjectOfType<PlayerController>();
        if (pc != null) player = pc.transform;
    }

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        // Enemies are spawned rotated 180°, so local "up" points down the screen.
        if (CompareTag("Enemy"))
        {
            transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);
        }
        else if (CompareTag("Enemy2"))
        {
            float zigZag = Mathf.Sin(Time.time * zigZagFrequency) * zigZagMagnitude * Time.deltaTime;
            Vector3 movement = new Vector3(zigZag, enemySpeed * Time.deltaTime, 0);
            transform.Translate(movement);
        }
        else if (CompareTag("Enemy3"))
        {
            // Descends and drifts toward the player's X position.
            transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);
            if (player != null)
            {
                float newX = Mathf.MoveTowards(transform.position.x, player.position.x, chaseSpeed * Time.deltaTime);
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
        }
    }
}
