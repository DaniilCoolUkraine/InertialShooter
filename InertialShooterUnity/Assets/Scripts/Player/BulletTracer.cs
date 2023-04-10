using UnityEngine;

namespace InertialShooter.Player
{
    public class BulletTracer : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private float _traceLiveTime = 5;

        public void CreateTrace(Vector2 direction)
        {
            var trace = Instantiate(_bullet, transform.position, Quaternion.identity);
            trace.GetComponent<ParticleSystem>().Play();
            
            trace.GetComponent<Rigidbody2D>().AddForce(-direction * 500, ForceMode2D.Impulse);
            
            Destroy(trace.gameObject, _traceLiveTime);
        }
    }
}