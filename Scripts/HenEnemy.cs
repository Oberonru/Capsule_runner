using UnityEngine;

namespace DefaultNamespace
{
    public class HenEnemy : Enemy
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float flyTime = 1f;
        [SerializeField] private float distanceLimit = 15f;
        [SerializeField] private float distanceDelta = 3f;
        private Rigidbody _rb;
        private Transform _playerPosition;
        private Vector3 _startPosition;
        private float _rndDistance;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _playerPosition = GameManager.Instance.Player.transform;
            _startPosition = transform.position;
            _rndDistance = Random.Range(distanceLimit - distanceDelta, distanceLimit + distanceDelta);
            print(_rndDistance + " rndDistance");
        }

        private void FixedUpdate()
        {
            float distance = Vector3.Distance(transform.position, _playerPosition.position);

            if (distance < _rndDistance)
            {
                Vector3 verticalShift = new Vector3(0f, 2f, 0f);
                Vector3 direction = (_playerPosition.position + verticalShift) - transform.position;
                Vector3 force = _rb.mass * (direction.normalized * speed - _rb.velocity) / flyTime;
                _rb.AddForce(force);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    _startPosition, speed * 5 * Time.deltaTime);
            }
        }
    }
}