using System;
using UnityEngine;

[Serializable]
public class BulletPull : Pull<Bullet>
{
    [SerializeField] private Bullet _bullet;
    
    public BulletPull(Bullet bullet, int pullSize) : base(bullet, pullSize)
    {
        
    }
}
