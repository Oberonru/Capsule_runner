using UnityEngine;

namespace DefaultNamespace
{
    public class HenEnemy : Enemy
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float flyTime = 1f;
        private Rigidbody _rb;
        private Transform playerPosition;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            playerPosition = GameManager.Instance.Player.transform;
        }

        private void FixedUpdate()
        {
            Vector3 verticalShift = new Vector3(0f, 2f, 0f);
            Vector3 direction = (playerPosition.position + verticalShift - transform.position).normalized;
            Vector3 force = _rb.mass * (direction * speed - _rb.velocity) / flyTime;
            _rb.AddForce(force);
        }
    }
}