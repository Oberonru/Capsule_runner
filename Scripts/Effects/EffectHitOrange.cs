using DefaultNamespace;
using UnityEngine;

public class EffectHitOrange : MonoBehaviour
{
    [SerializeField] private ParticleSystem effect;

    private void OnEnable()
    {
        Invoke("Release", 1f);
    }

    private void Release()
    {
        EffectHitOrangePull.Instance.ReleaseEffect(this);
    }
}
