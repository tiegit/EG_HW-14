using UnityEngine;

public class MagicMissle : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 4f;

    private Enemy _targetEnemy;
    private float _speed;
    private float _damage;

    public void Initialize(Enemy enemy, float speed, float damage)
    {
        _targetEnemy = enemy;
        _speed = speed;
        _damage = damage;

        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        if (_targetEnemy)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetEnemy.transform.position, _speed * Time.deltaTime);

            if (transform.position == _targetEnemy.transform.position)
            {
                AffectEnemy();
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }        
    }

    private void AffectEnemy()
    {
        _targetEnemy.SetDamage(_damage);
    }
}