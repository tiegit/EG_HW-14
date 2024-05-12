using UnityEngine;

[CreateAssetMenu(fileName = nameof(DamageIncreasingEffect), menuName = "Effects/OneTimeEffect/" + nameof(DamageIncreasingEffect))]
public class DamageIncreasingEffect : OneTimeEffect
{
    [SerializeField] private float _damageMultiplier = 1f;

    protected override void ApplyEffect()
    {
        _player.IncreaseDamage(_damageMultiplier);
    }
}