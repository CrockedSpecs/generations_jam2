using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class syncArrows : MonoBehaviour
{
    [SerializeField] private int arrowDirection;
    [SerializeField] private GameObject Arrow;
    private Collider2D Checker;



    // Start is called before the first frame update
    void Start()
    {
        Checker = GetComponent<Collider2D>();
        Checker.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        pressArrow();
    }

    void pressArrow()
    {
        switch (arrowDirection)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    StartCoroutine(ActivateArrowTemporarily());
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    StartCoroutine(ActivateArrowTemporarily());
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    StartCoroutine(ActivateArrowTemporarily());
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    StartCoroutine(ActivateArrowTemporarily());
                }
                break;
            default:
                break;
        }
    }

    IEnumerator ActivateArrowTemporarily()
    {
        Color alphaColor = Arrow.GetComponent<SpriteRenderer>().color;
        alphaColor.a = 1;
        Arrow.GetComponent<SpriteRenderer>().color = alphaColor;

        Checker.enabled = true;
        yield return new WaitForSeconds(0.05f);
        Checker.enabled = false;


        // Espera un corto tiempo antes de volver al estado original
        yield return new WaitForSeconds(0.15f);

        alphaColor.a = 0.4f;
        Arrow.GetComponent<SpriteRenderer>().color = alphaColor;


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("trigger")) // Asegúrate de que el objeto tenga esta etiqueta
        {
            // Calcula la distancia entre el objeto principal (objetoA) y el objeto con el que colisiona
            float distancia = Vector3.Distance(transform.position, collision.transform.position);

            // Imprime la distancia en la consola
            Debug.Log("La distancia en el momento de la colisión es: " + distancia);
        }
    }
}
