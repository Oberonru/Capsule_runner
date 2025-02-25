using DefaultNamespace;
using UnityEngine;

public class Carrot : Enemy
{
    private Rigidbody _rb;
    [SerializeField] private Rigidbody playerRigidbody;
    [Range(1, 100)] [SerializeField] private int force;
    private float _attackTimer = 0f;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        Vector3 attackDirection = playerRigidbody.position - transform.position;
        _rb.velocity = attackDirection.normalized * force;

        Invoke("Reset", 2f);
    }

    private void Update()
    {
        _attackTimer += Time.deltaTime;
    }

    private void Reset()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var component) && _attackTimer > 1)
        {
            _attackTimer = 0;
            component.ApplyDamage(AttackDamage);
        }
    }
}