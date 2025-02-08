using DefaultNamespace;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bumEffectPrefab;

    //Уррон от пули, как делать зависящим от оружия или еще чего то
    [SerializeField] private int damage = 1;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.TryGetComponent<IDamagable>(out var component))
        {
            component.ApplyDamage(damage);
        }

        Destroy(gameObject);
        GameObject effect = Instantiate(bumEffectPrefab, transform.position, Quaternion.identity);
    }
}