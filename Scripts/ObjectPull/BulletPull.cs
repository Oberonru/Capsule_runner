using UnityEngine;

public class BulletPull : MonoBehaviour
{
    private Pull<Bullet> _bulletPull;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int pullSize = 10;

    public static BulletPull Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        _bulletPull = new Pull<Bullet>(bulletPrefab, pullSize);
    }

    public Bullet GetBullet(Vector3 position, Quaternion rotation)
    {
        return _bulletPull.Get(position, rotation);
    }

    public void ReleaseBullet(Bullet bullet)
    {
        _bulletPull.Release(bullet);
    }

    public Bullet CreateBullet()
    {
        return _bulletPull.Create();
    }
}