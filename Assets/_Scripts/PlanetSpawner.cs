using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject[] planets; // Array de prefabs de planetas
    public float minInstantiateX = -7f;
    public float maxInstantiateX = 7f;
    public float instantiateY = 5.5f;
    public float spawnInterval = 20f;
    [Tooltip("Segundos antes de destruir un planeta (antes vivían para siempre).")]
    public float planetLifetime = 30f;

    void Start()
    {
        InvokeRepeating(nameof(InstantiatePlanet), 0f, spawnInterval);
    }

    void InstantiatePlanet()
    {
        if (planets == null || planets.Length == 0) return;

        Vector3 planetPos = new Vector3(Random.Range(minInstantiateX, maxInstantiateX), instantiateY);
        int randomIndex = Random.Range(0, planets.Length);
        GameObject planet = Instantiate(planets[randomIndex], planetPos, Quaternion.identity);
        Destroy(planet, planetLifetime);
    }
}
