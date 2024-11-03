using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class syncArrows : MonoBehaviour
{
    [SerializeField] private int arrowDirection;
    [SerializeField] private GameObject Arrow;
    public Collider2D Checker1;
    public Collider2D Checker2;
    public Collider2D Checker3;
    public Collider2D Checker4;


    // Start is called before the first frame update
    void Start()
    {
        Checker1.enabled = false;
        Checker2.enabled = false;
        Checker3.enabled = false;
        Checker4.enabled = false;
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

        Checker1.enabled = true;
        Checker2.enabled = true;
        Checker3.enabled = true;
        Checker4.enabled = true;

        // Espera un corto tiempo antes de volver al estado original
        yield return new WaitForSeconds(0.15f);

        alphaColor.a = 0.4f;
        Arrow.GetComponent<SpriteRenderer>().color = alphaColor;

        Checker1.enabled = false;
        Checker2.enabled = false;
        Checker3.enabled = false;
        Checker4.enabled = false;
    }
}
