using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSpawner : MonoBehaviour
{
    public GameObject upSpawn;
    public GameObject downSpawn;
    public GameObject leftSpawn;
    public GameObject rightSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject arrow = arrowPool.Instance.requestArrow(1);
            arrow.transform.position = leftSpawn.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            GameObject arrow = arrowPool.Instance.requestArrow(2);
            arrow.transform.position = upSpawn.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject arrow = arrowPool.Instance.requestArrow(3);
            arrow.transform.position = downSpawn.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject arrow = arrowPool.Instance.requestArrow(4);
            arrow.transform.position = rightSpawn.transform.position;
        }
    }
}
