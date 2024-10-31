using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Necesario para TextMeshPro

public class ControladorJuego : MonoBehaviour
{
    [SerializeField] private float tiempoMaximo = 3f; // 300 segundos equivale a 5 minutos
     [SerializeField] private TextMeshProUGUI textoTiempo; // Referencia al TextMeshPro
    private float tiempoActual = 0f;  // Empezamos desde 0 segundos
    private bool tiempoActivado = false;

    private void Start() 
    {
        ActivarTemporizador();
    }

    private void Update() 
    {
        if (tiempoActivado)
        {
            CambiarContador();
        }
    }

    private void CambiarContador()
    {
        tiempoActual += Time.deltaTime; // Incrementa el tiempo actual

        if (tiempoActual >= tiempoMaximo)
        {
            Debug.Log("¡Victoria!");  // Mensaje de victoria cuando llegamos a 5 minutos
            tiempoActivado = false;  // Detenemos el temporizador
        }

        // Opcional: Imprimir el tiempo en consola para visualizar el avance
        int minutos = Mathf.FloorToInt(tiempoActual / 60);  // Convertir tiempo a minutos
        int segundos = Mathf.FloorToInt(tiempoActual % 60); // Obtener los segundos restantes
        textoTiempo.text = $"{minutos:00}:{segundos:00}";  // Mostrar tiempo en formato mm:ss
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;
    }

    private void ActivarTemporizador()
    {
        tiempoActual = 0f;  // Reiniciar tiempo a 0 al iniciar
        CambiarTemporizador(true);
    }

    private void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }
}
