using UnityEngine;

namespace InertialShooter.Player
{
    public class PlayerAimArrow : MonoBehaviour
    {
        private Camera _mainCamera;

        private Vector3 _mousePosition;
        private Vector3 _aimDirection;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _aimDirection = (_mousePosition - transform.position).normalized;

            float angle = Mathf.Atan2(_aimDirection.x, _aimDirection.y) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(0, 0, -angle);
        }
    }
}