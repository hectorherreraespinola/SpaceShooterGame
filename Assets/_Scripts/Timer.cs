using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private bool running = true;

    void Awake()
    {
        // Establece la instancia única
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        UpdateText();
    }

    void OnDestroy()
    {
        if (instance == this) instance = null;
    }

    void Update()
    {
        if (!running) return;

        // Incrementa el tiempo transcurrido cada frame
        elapsedTime += Time.deltaTime;
        UpdateText();
    }

    public void StopTimer()
    {
        running = false;
    }

    void UpdateText()
    {
        if (timerText == null) return;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000f);

        timerText.text = string.Format("Time: {0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
