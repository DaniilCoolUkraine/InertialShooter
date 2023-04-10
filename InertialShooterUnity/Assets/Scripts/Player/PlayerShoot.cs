﻿using System;
using System.Collections;
using InertialShooter.Damageable;
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
                
                Vector3 playerPosition = transform.position;
                Vector2 direction = (playerPosition - _mouseClickPosition).normalized;
                
                RaycastHit2D hit = Physics2D.Raycast(playerPosition, -direction, 100, LayerMask.GetMask("Enemy"));

                if (hit.collider != null)
                {
                    hit.collider.GetComponent<Health>().TakeDamage(1);
                }
                
                _rb.AddForce(direction * _recoil, ForceMode2D.Impulse);

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