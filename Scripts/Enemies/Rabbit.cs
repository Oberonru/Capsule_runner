using UnityEngine;

public class Rabbit : Enemy
{
    [SerializeField] private Animator animator;
    [SerializeField] private int attackPeriod = 3;
    private float _timer;
    private Rigidbody _rb;
    private Rigidbody _playerRigidbody;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerRigidbody = DefaultNamespace.GameManager.Instance.Player.MoveController.Rb;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > attackPeriod)
        {
            _timer = 0;
            animator.SetTrigger("Attack");
        }
    }
}
