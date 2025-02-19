using UnityEngine;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject hercPrefab;
    [SerializeField] private List<GameObject> hercList { get; set; }

    public void InitUiHealth(int size)
    {
        hercList = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject herc = Instantiate(hercPrefab, transform);
            hercList.Add(herc);
        }
    }

    public void ShowHealth(int healthCount)
    {
        for (int i = 0; i < hercList.Count; i++)
        {
            if (i < healthCount)
            {
                hercList[i].SetActive(true);
            }
            else
            {
                hercList[i].SetActive(false);
            }
            
        }
    }
}