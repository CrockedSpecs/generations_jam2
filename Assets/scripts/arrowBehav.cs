using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowBehav : MonoBehaviour
{
    public float speed;
    public Collider2D trigger1;
    public Collider2D trigger2;
    public Collider2D trigger3;
    public Collider2D trigger4;
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        fall();
    }
    void fall()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
    }

    void getPoint()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "deadEnd")
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "checker")
        {
            getPoint();
            gameObject.SetActive(false);
        }
    }
}
