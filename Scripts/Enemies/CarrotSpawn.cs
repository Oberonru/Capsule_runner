using UnityEngine;

public class CarrotSpawn : MonoBehaviour
{
    [SerializeField] private GameObject carrotPrefab;
    [SerializeField] private Transform spawnPoint;

    private float _time;

    public void Spawn()
    {
        Instantiate(carrotPrefab, spawnPoint.position, Quaternion.identity);
    }
}