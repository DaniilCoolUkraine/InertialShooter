using UnityEngine;

namespace InertialShooter.Player
{
    public class PlayerDash : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _recoil;
        
        public void Dash(Vector2 direction)
        {
            _rb.AddForce(direction * _recoil, ForceMode2D.Impulse);
            _rb.AddTorque(Random.Range(10, 40));
        }
    }
}