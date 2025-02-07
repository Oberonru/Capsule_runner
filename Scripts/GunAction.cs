using UnityEngine;

public class GunAction : MonoBehaviour
{
    [SerializeField] private Transform aim;
    private Camera _camera;
    private Plane _plane;
    
    private void Start()
    {
        _plane = new Plane(-1 * Vector3.forward, Vector3.zero);
        _camera = FindObjectOfType<Camera>();
    }

    private void LateUpdate()
    {
        float distance;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        _plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        aim.position = point;

        Vector3 direction = point - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
