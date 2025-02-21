using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class EffectHit: MonoBehaviour
    {
        [SerializeField] private GameObject effectPrefab;
        [SerializeField] private ParticleSystem hit;

        private void OnEnable()
        {
            hit.Play();
            Invoke("Release", 1f);
        }

        private void Release()
        {
            EffectPull.Instance.ReleaseEffectHit(this);
        }
    }
}