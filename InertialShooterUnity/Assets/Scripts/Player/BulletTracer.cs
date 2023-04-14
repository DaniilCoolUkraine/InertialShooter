using UnityEngine;

namespace InertialShooter.Player
{
    public class BulletTracer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _bullet;
        [SerializeField] private float _traceLiveTime;

        [SerializeField] private float _forceMultiplier = 500;

        public void CreateTrace(Vector2 direction)
        {
            var trace = Instantiate(_bullet, transform.position, Quaternion.identity);
            trace.Play();

            trace.GetComponent<Rigidbody2D>().AddForce(-direction * _forceMultiplier, ForceMode2D.Impulse);

            Destroy(trace.gameObject, _traceLiveTime);
        }
    }
}