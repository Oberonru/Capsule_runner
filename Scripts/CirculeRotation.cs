using UnityEngine;

public class CirculeRotation : MonoBehaviour
{
    [Range(0, 360)] [SerializeField] private int rotateSpeed = 120;
    [SerializeField] private Vector3 rotateDirection;

    private void Update()
    {
        transform.Rotate(rotateDirection * (Time.deltaTime * rotateSpeed));
    }
}