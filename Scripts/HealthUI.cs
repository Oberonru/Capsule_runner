using UnityEngine;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject hercPrefab;
    private List<GameObject> hercList = new List<GameObject>();

    public void InitUiHealth(int size)
    {
        hercList.Clear();
        for (int i = 0; i < size; i++)
        {
            GameObject herc = Instantiate(hercPrefab, transform);
            hercList.Add(herc);
        }
    }

    public void UpdateMaxHealth()
    {
        
    }
    
    public void ShowHealth(int healthCount)
    {
        print(hercList.Count + " hercList.Count");
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