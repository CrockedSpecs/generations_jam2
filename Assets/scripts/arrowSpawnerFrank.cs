using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSpawnerFrank : MonoBehaviour
{
    public GameObject upSpawn;
    public GameObject downSpawn;
    public GameObject leftSpawn;
    public GameObject rightSpawn;

    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 3f;

    private bool musicIsPlaying = false;
    private Coroutine arrowSpawnCoroutine;

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
        while (musicIsPlaying)
        {
            Debug.Log("Comienzan a caer");
            int direction = Random.Range(1, 5);
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

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }
}
