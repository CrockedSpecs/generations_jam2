using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointManager : MonoBehaviour
{
    [SerializeField] private GameObject badPrefab;
    [SerializeField] private GameObject goodPrefab;
    [SerializeField] private GameObject ExcelentPrefab;

    [SerializeField] public int globalPoints = 0;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPoint(int points)
    {
        globalPoints += points;
    }
}
