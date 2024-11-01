using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class syncArrows : MonoBehaviour
{
    [SerializeField] private int arrowDirection;
    [SerializeField] private GameObject Arrow;
    public Collider2D topCheck;
    public Collider2D medCheck;
    public Collider2D bottomCheck;

    // Start is called before the first frame update
    void Start()
    {
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
                if (Input.GetKey(KeyCode.A)){
                    Color alphaColor = Arrow.GetComponent<SpriteRenderer>().color;
                    alphaColor.a = 1;
                    Arrow.GetComponent<SpriteRenderer>().color = alphaColor;
                }
                else
                {
                    Color alphaColor = Arrow.GetComponent<SpriteRenderer>().color;
                    alphaColor.a = 0.4f;
                    Arrow.GetComponent<SpriteRenderer>().color = alphaColor;
                }
                break;
            case 1:
                if (Input.GetKey(KeyCode.W))
                {
                    Color alphaColor = Arrow.GetComponent<SpriteRenderer>().color;
                    alphaColor.a = 1;
                    Arrow.GetComponent<SpriteRenderer>().color = alphaColor;
                }
                else
                {
                    Color alphaColor = Arrow.GetComponent<SpriteRenderer>().color;
                    alphaColor.a = 0.4f;
                    Arrow.GetComponent<SpriteRenderer>().color = alphaColor;
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.S))
                {
                    Color alphaColor = Arrow.GetComponent<SpriteRenderer>().color;
                    alphaColor.a = 1f;
                    Arrow.GetComponent<SpriteRenderer>().color = alphaColor;
                }
                else
                {
                    Color alphaColor = Arrow.GetComponent<SpriteRenderer>().color;
                    alphaColor.a = 0.4f;
                    Arrow.GetComponent<SpriteRenderer>().color = alphaColor;
                }
                break;
            case 3:
                if (Input.GetKey(KeyCode.D))
                {
                    Color alphaColor = Arrow.GetComponent<SpriteRenderer>().color;
                    alphaColor.a = 1;
                    Arrow.GetComponent<SpriteRenderer>().color = alphaColor;
                }
                else
                {
                    Color alphaColor = Arrow.GetComponent<SpriteRenderer>().color;
                    alphaColor.a = 0.4f;
                    Arrow.GetComponent<SpriteRenderer>().color = alphaColor;
                }
                break;
            default:
                break;

        }
    }
}
