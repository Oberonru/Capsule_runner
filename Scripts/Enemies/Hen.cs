using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Hen : Enemy
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float flyTime = 1f;
        [SerializeField] private float distanceLimit = 15f;
        [SerializeField] private float distanceDelta = 3f;
        private Rigidbody _rb;
        private Transform _playerPosition;
        private Vector3 _startPosition;
        private float _rndDistance;
        private float _attackTimer = 0f;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _playerPosition = GameManager.Instance.Player.transform;
            _startPosition = transform.position;
            _rndDistance = Random.Range(distanceLimit - distanceDelta, distanceLimit + distanceDelta);
        }

        private void Update()
        {
            _attackTimer += Time.deltaTime;
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
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Player>(out var component) && _attackTimer > 1)
            {
                _attackTimer = 0;
                component.ApplyDamage(AttackDamage);
            }
        }
    }
}