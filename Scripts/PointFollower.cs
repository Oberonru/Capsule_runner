using UnityEngine;

public class PointFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float lerpSpeed = 1f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed);
    }
}
