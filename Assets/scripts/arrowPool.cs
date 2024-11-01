using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowPool : MonoBehaviour
{
    [SerializeField] private GameObject upArrowPrefab;
    [SerializeField] private GameObject downArrowPrefab;
    [SerializeField] private GameObject leftArrowPrefab;
    [SerializeField] private GameObject rightArrowPrefab;
    private int poolSize = 15;
    [SerializeField] private List<GameObject> upArrowList;
    [SerializeField] private List<GameObject> downArrowList;
    [SerializeField] private List<GameObject> leftArrowList;
    [SerializeField] private List<GameObject> rightArrowList;

    private static arrowPool instance;
    public static arrowPool Instance { get { return instance; } }
    // Start is called before the first frame update
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
        addArrowsToPool(poolSize);
    }

    private void addArrowsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            CreateArrow(upArrowPrefab, upArrowList);
            CreateArrow(downArrowPrefab, downArrowList);
            CreateArrow(leftArrowPrefab, leftArrowList);
            CreateArrow(rightArrowPrefab, rightArrowList);
        }
    }

    private void CreateArrow(GameObject arrowPrefab, List<GameObject> arrowList)
    {
        GameObject arrow = Instantiate(arrowPrefab);
        arrow.SetActive(false);
        arrow.transform.parent = transform;
        arrowList.Add(arrow);
    }

    public GameObject requestArrow(int arrowNumber)
    {
        List<GameObject> selectedList = null;

        switch (arrowNumber)
        {
            case 1:
                selectedList = leftArrowList;
                break;
            case 2:
                selectedList = upArrowList;
                break;
            case 3:
                selectedList = downArrowList;
                break;
            case 4:
                selectedList = rightArrowList;
                break;
            default:
                return null;
        }
        foreach (GameObject arrow in selectedList)
        {
            if (!arrow.activeSelf)
            {
                arrow.SetActive(true);
                return arrow;
            }
        }
        return null;
    }
}
