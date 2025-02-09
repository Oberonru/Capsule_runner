using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody => _rb;
    //[SerializeField] private GameObject bumEffectPrefab;
    [SerializeField] private Rigidbody _rb;
    private int _damage = 1;

    public void Init(int damage)
    {
        this._damage = damage;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Invoke("DestroyOfPull", 4f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.TryGetComponent<IDamagable>(out var component))
        {
            component.ApplyDamage(_damage);
        }

        DestroyOfPull();
        EffectHit effect = EffectPull.Instance.GetEffectHit(this.transform.position, this.transform.rotation);

        // фиг знает, но не выполняется
        var value =  RealiseEffectWithDelay(effect, 5f);
    }

    private IEnumerator RealiseEffectWithDelay(EffectHit effect, float delay)
    {
        yield return new WaitForSeconds(delay);
        EffectPull.Instance.ReleaseEffectHit(effect);
    }
    
    private void DestroyOfPull()
    {
        BulletPull.Instance.ReleaseBullet(this);
    }
}