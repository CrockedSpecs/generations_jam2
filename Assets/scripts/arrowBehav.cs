using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowBehav : MonoBehaviour
{
    public float speed;
    void Start()
    {
        speed = 4f;
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "deadEnd")
        {
            pointManager.Instance.potionLives--;
            gameObject.SetActive(false);
        }
    }
}
