using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float missileSpeed = 30.0f;

    void Update()
    {
        transform.Translate(Vector3.up * missileSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.IsEnemy(collision.gameObject)) return;

        if (GameManager.instance != null && GameManager.instance.explosion != null)
        {
            GameObject fx = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);
            Destroy(fx, 2.0f);
        }
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
