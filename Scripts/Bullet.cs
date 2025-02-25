using DefaultNamespace;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage = 1;
    [SerializeField] private Rigidbody rb;
    public Rigidbody Rigidbody => rb;

    public void Init(int damage)
    {
        this._damage = damage;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Invoke("RealizeOfPull", 3f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.TryGetComponent<IDamagable>(out var component))
        {
            component.ApplyDamage(_damage);
        }

        RealizeOfPull();
        EffectHitPull.Instance.GetEffectHit(this.transform.position, this.transform.rotation);
        
    }

    private void RealizeOfPull()
    {
        BulletPull.Instance.ReleaseBullet(this);
    }
}