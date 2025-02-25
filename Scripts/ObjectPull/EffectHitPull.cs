using UnityEngine;

namespace DefaultNamespace
{
    public class EffectHitPull : MonoBehaviour
    {
        [SerializeField] private EffectHit effectPrefab;
        [SerializeField] private int pullSize = 10;
        private Pull<EffectHit> _effectPull;

        public static EffectHitPull Instance{ get; private set; }

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
            
            _effectPull = new Pull<EffectHit>(effectPrefab, pullSize);
        }
        
        public EffectHit GetEffectHit(Vector3 position, Quaternion rotation)
        {
            return _effectPull.Get(position, rotation);
        }

        public void ReleaseEffectHit(EffectHit effectPrefab)
        {
            _effectPull.Release(effectPrefab);
        }
        
        public EffectHit CreateEffectHit()
        {
            return _effectPull.Create();
        }
    }
}