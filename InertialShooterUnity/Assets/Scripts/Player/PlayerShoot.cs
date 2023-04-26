using InertialShooter.Chips;
using InertialShooter.Chips.Weapons;
using UnityEngine;

namespace InertialShooter.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        public WeaponChip WeaponChip { get; private set; }

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
                Shoot();
            }
        }

        public void SetWeaponChip(WeaponChip weaponChip)
        {
            WeaponChip = weaponChip;
        }
        
        private void Shoot()
        {
            _mouseClickPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (transform.position - _mouseClickPosition).normalized;

            WeaponChip.Shoot(direction);
        }
    }
}