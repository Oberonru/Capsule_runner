using UnityEngine;

public class Carrot : Enemy
{
    private Rigidbody _rb;
    [SerializeField] private Rigidbody playerRigidbody;
    [Range(1, 100)] [SerializeField] private int force;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        Vector3 attackDirection = playerRigidbody.position - transform.position;
        _rb.velocity = attackDirection.normalized * force;
        
        Invoke("Reset", 2f);
    }

    private void Reset()
    {
        Destroy(gameObject);
    }
}  