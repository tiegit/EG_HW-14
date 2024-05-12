using UnityEngine;

[CreateAssetMenu(fileName = nameof(ShadowMisslesEffect), menuName = "Effects/ContinuousEffect/" + nameof(ShadowMisslesEffect))]
public class ShadowMisslesEffect : ContinuousEffect
{
    [SerializeField, Space(10)] private ShadowMissle _shadowMisslePrefab;
    [SerializeField] private float _bulletSpeed;
    private float _baseDamage = 20f;
    private int _pathCount = 2;

    protected override void Produce()
    {
        Transform playerTransform = _player.transform;
        int number = 5;
        var damage = _baseDamage * _player.DamageMultiplier;

        for (int i = 0; i < number; i++)
        {
            float angle = (360f / number) * i;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * playerTransform.forward;
            ShadowMissle newBullet = Instantiate(_shadowMisslePrefab, playerTransform.position, Quaternion.identity);
            newBullet.Initialize(direction * _bulletSpeed, damage, _pathCount);
        }
    }
}
