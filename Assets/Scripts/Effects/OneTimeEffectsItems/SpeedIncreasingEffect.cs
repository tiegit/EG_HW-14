using UnityEngine;

[CreateAssetMenu(fileName = nameof(SpeedIncreasingEffect), menuName = "Effects/OneTimeEffect/" + nameof(SpeedIncreasingEffect))]
public class SpeedIncreasingEffect : OneTimeEffect
{
    [SerializeField] private float _speedMultiplier = 1f;

    protected override void ApplyEffect()
    {
        _player.IncreaseSpeed(_speedMultiplier);
    }
}
