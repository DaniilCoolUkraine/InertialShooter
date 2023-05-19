using UnityEngine;

namespace InertialShooter.Zones
{
    public class SpeedZone : MonoBehaviour
    {
        [Min(0)]
        [SerializeField] private float _speedMultiplier;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

                rb.velocity += rb.velocity * _speedMultiplier * Time.deltaTime;
            }
        }
    }
}