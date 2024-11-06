using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSpawnerFrank : MonoBehaviour
{
    public GameObject upSpawn;
    public GameObject downSpawn;
    public GameObject leftSpawn;
    public GameObject rightSpawn;

    private bool musicIsPlaying = false;
    private Coroutine arrowSpawnCoroutine;
    

    private void Start()
    {
        
    }
    void Update()
    {
        CheckMusicStatus();
    }

    void CheckMusicStatus()
    {
        if (audioManager.Instance.levelMusic.isPlaying && !musicIsPlaying)
        {
            musicIsPlaying = true;
            Debug.Log("Audio ha comenzado");

            // Inicia o reinicia la coroutine de generación de flechas
            if (arrowSpawnCoroutine != null)
                StopCoroutine(arrowSpawnCoroutine);

            arrowSpawnCoroutine = StartCoroutine(SpawnArrows());
        }
        else if (!audioManager.Instance.levelMusic.isPlaying && musicIsPlaying)
        {
            musicIsPlaying = false;
            Debug.Log("Audio se ha detenido");

            // Detiene la generación de flechas cuando la música se detiene
            if (arrowSpawnCoroutine != null)
                StopCoroutine(arrowSpawnCoroutine);
        }
    }

    IEnumerator SpawnArrows()
    {

        int spawnCount = 3; // Comienza con 3 flechas
        int cycleCount = 0; // Contador para llevar el registro de los ciclos

        while (musicIsPlaying)
        {

            // Hacer el ciclo de generación de flechas
            for (int i = 0; i < spawnCount; i++)
            {
                // Decide si hay una probabilidad de generar 2 o 3 flechas al mismo tiempo
                if (Random.Range(0f, 1f) < 0.1f && i < i-1)  // 10% de probabilidad
                {
                    int additionalArrows = Random.Range(1, 3);
                    if (additionalArrows > 1)
                    {
                        i++;
                    }// Genera 1 o 2 flechas
                    HashSet<int> usedDirections = new HashSet<int>(); // Usamos un HashSet para evitar direcciones repetidas

                    for (int j = 0; j < additionalArrows; j++)
                    {
                        int direction;
                        // Asegurarse de que la dirección no se repita
                        do
                        {
                            direction = Random.Range(1, 5);
                        } while (usedDirections.Contains(direction)); // Si la dirección ya fue usada, generamos otra
                        usedDirections.Add(direction); // Añadir la dirección al conjunto de usadas

                        // Generamos la flecha con la dirección única
                        GenerateArrow(direction);
                    }
                }
                else
                {
                    // Si no se elige generar flechas extras, solo genera una
                    GenerateArrow();
                }

                // Espera un tiempo aleatorio entre 0.2f y 0.5f segundos antes de generar otra flecha
                yield return new WaitForSeconds(Random.Range(0.3f, 0.6f));
            }

            // Incrementa el contador de ciclos
            cycleCount++;

            // Cada 2 ciclos, aumenta spawnCount
            if (cycleCount % 2 == 0)
            {
                spawnCount = Mathf.Min(spawnCount + 1, 30);  // No dejar que el número de flechas supere 30
            }


            if (pointManager.Instance.potionLives > 0)
            {
                pointManager.Instance.addPotion(1);
                
            }
            else
            {
                pointManager.Instance.restLives();
                pointManager.Instance.addPoint(-10);
            }
            pointManager.Instance.potionLives = 3;
            // Espera de 1 segundo entre ciclos de flechas
            yield return new WaitForSeconds(1f);
        }
    }

    // Función para generar una flecha con una dirección específica
    void GenerateArrow(int direction = 0)
    {
        // Si no se pasa una dirección, se genera aleatoriamente
        if (direction == 0)
        {
            direction = Random.Range(1, 5);
        }

        GameObject arrow = arrowPool.Instance.requestArrow(direction);

        switch (direction)
        {
            case 1:
                arrow.transform.position = leftSpawn.transform.position;
                break;
            case 2:
                arrow.transform.position = upSpawn.transform.position;
                break;
            case 3:
                arrow.transform.position = downSpawn.transform.position;
                break;
            case 4:
                arrow.transform.position = rightSpawn.transform.position;
                break;
        }
    }

}
