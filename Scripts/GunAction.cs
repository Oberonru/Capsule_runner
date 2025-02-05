using UnityEngine;

public class GunAction : MonoBehaviour
{
    [SerializeField] private Transform aim;
    private Plane _plane;
    
    private void Start()
    {
        _plane = new Plane(-1 * Vector3.forward, Vector3.zero);
    }

    private void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        aim.position = point;

        Vector3 direction = point - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
