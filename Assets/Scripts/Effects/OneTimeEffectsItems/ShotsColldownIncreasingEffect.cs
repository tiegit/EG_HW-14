using UnityEngine;

[CreateAssetMenu(fileName = nameof(ShotsColldownIncreasingEffect), menuName = "Effects/OneTimeEffect/" + nameof(ShotsColldownIncreasingEffect))]
public class ShotsColldownIncreasingEffect : OneTimeEffect
{
    [SerializeField] private float _shotsColldownMultiplier = 1f;

    protected override void ApplyEffect()
    {
        _player.IncreaseShotsColldown(_shotsColldownMultiplier);
    }
}