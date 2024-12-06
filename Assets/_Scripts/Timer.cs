using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Establece la instancia única
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Llama al método Timer para iniciar el contador de tiempo
        CounterTime();
    }

    // Update is called once per frame
    void Update()
    {
        // Incrementa el tiempo transcurrido cada frame
        elapsedTime += Time.deltaTime;

        // Actualiza el texto del contador de tiempo con el formato deseado
        CounterTime();
    }

    void CounterTime()
    {
        // Calcula los minutos y segundos
        
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);

        // Actualiza el texto del contador de tiempo
        timerText.text = "Time: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds,milliseconds);
    }
}




