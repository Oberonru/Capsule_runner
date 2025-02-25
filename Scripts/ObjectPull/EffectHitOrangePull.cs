using UnityEngine;

namespace DefaultNamespace
{
    public class EffectHitOrangePull : MonoBehaviour
    {
        [SerializeField] private EffectHitOrange prefab;
        [SerializeField] private int size = 10;
        private Pull<EffectHitOrange> _effectHitOrangePull;

        public static EffectHitOrangePull Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            _effectHitOrangePull = new Pull<EffectHitOrange>(prefab, size);
        }

        public EffectHitOrange GetEffect(Vector3 position, Quaternion rotation)
        {
            return _effectHitOrangePull.Get(position, rotation);
        }

        public void ReleaseEffect(EffectHitOrange prefab)
        {
            _effectHitOrangePull.Release(prefab);
        }

        public EffectHitOrange CreateEffect()
        {
            return _effectHitOrangePull.Create();
        }
    }
}