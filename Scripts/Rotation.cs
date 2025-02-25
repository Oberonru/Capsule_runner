using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotateDirection;

    private void Update()
    {
        transform.Rotate(rotateDirection * Time.deltaTime);
    }
}