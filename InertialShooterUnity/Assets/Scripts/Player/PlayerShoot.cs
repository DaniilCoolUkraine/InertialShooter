using System;
using System.Collections;
using InertialShooter.Damageable;
using UnityEngine;

namespace InertialShooter.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        public event Action<Vector2> OnShoot;
        public event Action<float> OnReload;

        [SerializeField] private float _cooldown;
        [SerializeField] private float _shootDistance = 100;

        private bool _canShoot = true;

        private Camera _mainCamera;
        private Vector3 _mouseClickPosition;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }

        private void Fire()
        {
            if (_canShoot)
            {
                _mouseClickPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector3 playerPosition = transform.position;
                Vector2 direction = (playerPosition - _mouseClickPosition).normalized;

                OnShoot?.Invoke(direction);

                RaycastHit2D[] hits = Physics2D.RaycastAll(playerPosition, -direction, _shootDistance,
                    LayerMask.GetMask("Enemy"));
                if (hits.Length > 0)
                {
                    foreach (var hit in hits)
                        hit.collider.GetComponent<Health>().TakeDamage(1);
                }

                StartCoroutine(ShootCooldown());
            }
        }

        private IEnumerator ShootCooldown()
        {
            OnReload?.Invoke(_cooldown);

            _canShoot = false;
            yield return new WaitForSeconds(_cooldown);
            _canShoot = true;
        }
    }
}