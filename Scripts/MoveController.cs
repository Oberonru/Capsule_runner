using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontal;
    private bool _isGround;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float squatSpeed = 1f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float friction;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private Transform aimTransform;
    private float angle;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float currentSpeed = _isGround ? speed : speed / 3;
        _rb.AddForce(currentSpeed * _horizontal, 0, 0, ForceMode.VelocityChange);

        //     //drag только по оси х
        _rb.AddForce(-1 * _rb.velocity.x * friction, 0, 0, ForceMode.VelocityChange);
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        Vector3 rotateDirection = aimTransform.position - transform.position;
        //тут не логично и не понятно, чтобы повернуть объект в направлении оси z
        //нужно оставить только X ветку, а по факту вращается ось Y
        transform.rotation = Quaternion.LookRotation(new Vector3(rotateDirection.x, 0, 0));

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl) ||
            _isGround == false)
        {
            Squat();
        }
        else
        {
            characterTransform.localScale =
                Vector3.Lerp(characterTransform.localScale, new Vector3(1, 1, 1), squatSpeed);
        }
    }

    private void Jump()
    {
        _rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
    }

    private void Squat()
    {
        Vector3 scale = characterTransform.localScale;
        characterTransform.localScale = Vector3.Lerp(scale, new Vector3(1, 0.5f, 1), squatSpeed * 2);
    }

    private void OnCollisionStay(Collision other)
    {
        foreach (var contact in other.contacts)
        {
            float angle = Vector3.Angle(contact.normal, Vector3.up);
            _isGround = angle <= 45f;
        }
    }

    private void OnCollisionExit()
    {
        _isGround = false;
    }
}