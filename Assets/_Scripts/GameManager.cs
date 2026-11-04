using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] enemies;
    public float minInstantiateX = -7f;
    public float maxInstantiateX = 7f;
    public float enemyDestroyTime = 10f;

    [Header("Particle Effect")]
    public GameObject explosion;
    public GameObject muzzleFlash;

    [Header("Game Over")]
    public float restartDelay = 2f;

    public bool IsGameOver { get; private set; }

    public static bool IsEnemy(GameObject go)
    {
        return go.CompareTag("Enemy") || go.CompareTag("Enemy2") || go.CompareTag("Enemy3");
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InvokeRepeating(nameof(InstantiateEnemy), 1f, 1f);
    }

    void InstantiateEnemy()
    {
        if (IsGameOver || enemies == null || enemies.Length == 0) return;

        Vector3 enemyPos = new Vector3(Random.Range(minInstantiateX, maxInstantiateX), 5.5f);
        int randomIndex = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[randomIndex], enemyPos, Quaternion.Euler(0f, 0f, 180f));
        Destroy(enemy, enemyDestroyTime);
    }

    public void GameOver()
    {
        if (IsGameOver) return;
        IsGameOver = true;

        CancelInvoke(nameof(InstantiateEnemy));
        if (Timer.instance != null) Timer.instance.StopTimer();

        StartCoroutine(RestartAfterDelay());
    }

    IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
