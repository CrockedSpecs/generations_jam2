using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSpawnerFrank : MonoBehaviour
{
    public GameObject upSpawn;
    public GameObject downSpawn;
    public GameObject leftSpawn;
    public GameObject rightSpawn;

    // Variables para controlar el tiempo de aparición
    [SerializeField] private float minSpawnTime = 1f; // Tiempo mínimo de espera
    [SerializeField] private float maxSpawnTime = 3f; // Tiempo máximo de espera

    void Start()
    {
        StartCoroutine(SpawnArrows()); // Inicia la coroutine al comenzar
    }

    IEnumerator SpawnArrows()
    {
        while (true)
        {
            // Espera un tiempo aleatorio entre minSpawnTime y maxSpawnTime
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            int direction = Random.Range(1, 5); // Número aleatorio para elegir la dirección
            GameObject arrow = arrowPool.Instance.requestArrow(direction);

            // Asigna la posición en función de la dirección
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
}


