using UnityEngine;

namespace InertialShooter.Zones
{
    public class SlowingZone : MonoBehaviour
    {
        [Min(0)]
        [SerializeField] private float _slowMultiplier;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                Rigidbody2D rb = col.GetComponent<Rigidbody2D>();

                rb.drag = _slowMultiplier;
                rb.gravityScale = 0;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

                rb.drag = 0;
                rb.gravityScale = 1;
            }
        }
    }
}
