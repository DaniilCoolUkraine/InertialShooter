using UnityEngine;
using UnityEngine.AI;

namespace InertialShooter.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Vector2 _enemySpeedBounds;

        private Transform _target;

        private void Awake()
        {
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        private void Start()
        {
            _agent.speed = Random.Range(_enemySpeedBounds.x, _enemySpeedBounds.y);
        }

        private void Update()
        {
            if (_target != null)
            {
                _agent.SetDestination(_target.position);
            }
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}