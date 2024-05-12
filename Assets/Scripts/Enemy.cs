using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 50f;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _rotationLerpRate = 3f;

    [SerializeField] private float _attackPeriod = 1f;
    [SerializeField] private float _dps;
    [SerializeField] private float _positionChangeRadius = 30f;

    [SerializeField] private GameObject _dieEffect;

    private Transform _playerTransform;
    private EnemyManager _enemyManager;
    private Rigidbody _rigidbody;
    private PlayerHealth _playerHealth;
    private float _attackTimer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Transform playerTransform, EnemyManager enemyManager)
    {
        _playerTransform = playerTransform;
        _enemyManager = enemyManager;
    }

    private void Update()
    {
        if (_playerHealth)
        {
            _attackTimer += Time.deltaTime;

            if (_attackTimer > _attackPeriod)
            {
                _playerHealth.TakeDamage(_dps * _attackPeriod);
                _attackTimer = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_playerTransform)
        {
            Vector3 toPlayer = _playerTransform.position - transform.position;

            Quaternion toPlayerRotation = Quaternion.LookRotation(toPlayer, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toPlayerRotation, Time.deltaTime * _rotationLerpRate);

            _rigidbody.velocity = transform.forward * _speed;

            if (toPlayer.magnitude > _positionChangeRadius)
            {
                transform.position += toPlayer * 1.95f;
            }
        }
    }

    public void SetDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(_dieEffect, transform.position, Quaternion.identity);
        _enemyManager.RemoveEnemy(this);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() is PlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            _playerHealth = null;
        }
    }
}
