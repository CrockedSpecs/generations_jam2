using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointManager : MonoBehaviour
{
    [SerializeField] private GameObject badPrefab;
    [SerializeField] private GameObject goodPrefab;
    [SerializeField] private GameObject ExcelentPrefab;

    public int globalPoints = 0;
    public int difficulty = 3;
    public int potionsNumber = 0;
    public int potionLives = 3;
    public int lives = 3;

    // Start is called before the first frame update

    private static pointManager instance;

    public static pointManager Instance { get { return instance; } }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void addPoint(int points)
    {
        globalPoints += points;
    }

    public void addPotion(int number)
    {
        potionsNumber =+ number;
    }

    public void restLives()
    {
        lives--;
    }
}
