using UnityEngine;
using System.Collections;
using DefaultNamespace;

public class Bullet : MonoBehaviour
{
    private int _damage = 1;
    [SerializeField] private Rigidbody _rb;
    public Rigidbody Rigidbody => _rb;

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
        //Клон пули уже разрушился и уже выдает ошибку, когда пробую вызвать эффеект
        EffectHit effect = EffectPull.Instance.GetEffectHit(this.transform.position, this.transform.rotation);
        //StartCoroutine(RealiseEffectWithDelay(effect, 1f));
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