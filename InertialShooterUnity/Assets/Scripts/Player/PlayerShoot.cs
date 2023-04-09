using System;
using System.Collections;
using UnityEngine;

namespace InertialShooter.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        public event Action OnShoot;

        [SerializeField] private Rigidbody2D _rb;
        
        [SerializeField] private float _cooldown;
        [SerializeField] private float _recoil;
        
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
                
                _rb.AddForce((Vector2)(transform.position - _mouseClickPosition).normalized * _recoil, ForceMode2D.Impulse);

                StartCoroutine(ShootCooldown());
            }
        }
        
        private IEnumerator ShootCooldown()
        {
            _canShoot = false;
            yield return new WaitForSeconds(_cooldown);
            _canShoot = true;
        }
    }
}