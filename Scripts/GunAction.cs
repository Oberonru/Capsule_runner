using UnityEngine;

public class GunAction : MonoBehaviour
{
    private Camera _camera;
    private Plane _plane;
    [SerializeField] private Transform aim;

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

        aim.position = new Vector3(point.x, point.y, -1f);

        Vector3 direction = point - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}