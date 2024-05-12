using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(MagicMissleEffect), menuName = "Effects/ContinuousEffect/" + nameof(MagicMissleEffect))]
public class MagicMissleEffect : ContinuousEffect
{
    [SerializeField, Space(10)] private MagicMissle _magicMisslePrefab;
    [SerializeField] private float _bulletSpeed = 8f;
    [SerializeField] private float _delayBetwinShots = 0.2f;
    private float _baseDamage = 20f;

    protected override void Produce()
    {
        _effectsManager.StartCoroutine(EffectProcess());
    }

    private IEnumerator EffectProcess()
    {
        int number = 4;
        Enemy[] nearestEnemies = _enemyManager.GetNearest(_player.transform.position, number);

        if (nearestEnemies.Length > 0)
        {
            var delayTime = new WaitForSeconds(_delayBetwinShots);
            var damage = _baseDamage * _player.DamageMultiplier;

            for (int i = 0; i < nearestEnemies.Length; i++)
            {
                Vector3 position = _player.transform.position;
                MagicMissle magicMissle = Instantiate(_magicMisslePrefab, position, Quaternion.identity);
                magicMissle.Initialize(nearestEnemies[i], damage, _bulletSpeed);
                yield return delayTime;
            }
        }
    }
}
