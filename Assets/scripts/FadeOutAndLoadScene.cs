using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutAndLoadScene : MonoBehaviour
{
   public CanvasGroup fadePanel; // Asigna aquí el Panel con CanvasGroup
    public float fadeDuration = 2f; // Duración del fade-out en segundos
    public float waitTimeBeforeFade = 3f; // Tiempo de espera antes de comenzar el fade-out
    public string nextSceneName = "LoadingScreen"; // Nombre de la escena de carga

    void Start()
    {
        // Inicia la secuencia de espera y fade-out
        StartCoroutine(FadeOutAndChangeScene());
    }

    IEnumerator FadeOutAndChangeScene()
    {
        // Espera antes de iniciar el fade-out
        yield return new WaitForSeconds(waitTimeBeforeFade);

        // Realiza el fade-out
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadePanel.alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            yield return null;
        }

        // Asegúrate de que el fade-out esté completo
        fadePanel.alpha = 0f;

        // Espera un momento adicional si deseas (opcional)
        yield return new WaitForSeconds(1f); // Ajusta el tiempo si deseas una pequeña pausa

        // Carga la siguiente escena
        SceneManager.LoadScene(nextSceneName);
    }
}
