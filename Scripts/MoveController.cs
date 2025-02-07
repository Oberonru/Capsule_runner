using UnityEngine;

public class MoveController : MonoBehaviour
{
    #region fields
    
    private Rigidbody _rb;
    private float _horizontal;
    private bool _isGround;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float squatSpeed = 1f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float friction;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Transform bodyTransform;
    private float _angle;
    private float _mouseX;
    #endregion

    #region start

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    #endregion

    #region updates
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
        _mouseX = -1 * Input.GetAxis("Mouse X");
        
        _angle += _mouseX;
        _angle = Mathf.Clamp(_angle, 160f, 210f);

        Vector3 rotateDirection = aimTransform.position - bodyTransform.position;
        //тут не логично и не понятно, чтобы повернуть объект в направлении оси z
        //нужно оставить только X ветку, а по факту вращается ось Y
        //rotateDirection.x = Mathf.Clamp(rotateDirection.x, 130f, 210f);
            
        //bodyTransform.rotation = Quaternion.LookRotation(new Vector3(rotateDirection.x, 0, 0));
        transform.localEulerAngles = new Vector3(0, _angle, 0);

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

    #endregion

    #region methods

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

    #endregion
}