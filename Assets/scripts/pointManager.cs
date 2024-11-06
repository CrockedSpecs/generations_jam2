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
    public bool midLevel = false;
    public AudioSource gameSong;
    public bool isMusicOn;

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

    public void addPotion()
    {

    }
}
