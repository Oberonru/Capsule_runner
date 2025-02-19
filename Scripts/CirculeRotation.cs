using UnityEngine;

public class CirculeRotation : MonoBehaviour
{
    [Range(0, 360)] [SerializeField] private int rotateSpeed = 120;

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}