using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class LoadingScene : MonoBehaviour
{
    public Slider progressBar; // Asigna aquí el Slider en el Inspector
    public string sceneToLoad = "MainScene"; // Cambia al nombre de tu escena principal

    void Start()
    {
        // Inicia la carga asíncrona de la escena
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        // Comienza a cargar la escena de forma asíncrona
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);

        // Mientras la escena se carga, actualiza la barra de progreso
        while (!operation.isDone)
        {
            // `operation.progress` devuelve un valor entre 0 y 0.9 durante la carga
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress; // Actualiza el Slider

            yield return null;
        }
    }
}
