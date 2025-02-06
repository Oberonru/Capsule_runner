using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bumEffectPrefab;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        GameObject effect = Instantiate(bumEffectPrefab, transform.position, Quaternion.identity);
    }
}
