using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontal;
    private bool _isGround;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float friction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(speed * _horizontal, 0, 0, ForceMode.VelocityChange);
        //drag только по оси х
        _rb.AddForce(-1 * _rb.velocity.x * friction, 0, 0, ForceMode.VelocityChange);
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SchowNormale();
        }
    }

    private void SchowNormale()
    {
        float normale = Vector3.Dot(transform.right, new Vector3(_horizontal, 0, 0));

        print("normale : " + normale);
    }

    private void Jump()
    {
        _rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
    }

    private void OnCollisionStay(Collision other)
    {
        foreach (var contact in other.contacts)
        {
            float angle = Vector3.Angle(contact.normal, Vector3.up);
            print(angle);
            _isGround = angle <= 45f;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _isGround = false;
    }
}