using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Collider))]

public class ShadowMissle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _lifeTime = 5f;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private float _damage;
    private int _passCount;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();        
    }

    public void Initialize(Vector3 velocity, float damage, int passCount)
    {
        transform.rotation = Quaternion.LookRotation(velocity);
        _damage = damage;
        _rigidbody.velocity = velocity;
        _passCount = passCount;

        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() is Enemy enemy)
        {
            enemy.SetDamage(_damage);
            _passCount--;

            if (_passCount == 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        _rigidbody.velocity = Vector3.zero;
        _collider.enabled = false;
        _particleSystem.Stop();
        Destroy(gameObject, _lifeTime / 3);
    }
}