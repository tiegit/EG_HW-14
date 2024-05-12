using UnityEngine;

public abstract class ContinuousEffect : Effect
{
    [SerializeField] protected float _colldown = 1;
    private float _timer;

    public void ProcessFrame(float frameTime)
    {
        _timer += frameTime;

        if (_timer > _colldown * _player.ShotsColldownMultiplier)
        {
            Produce();
            _timer = 0;
        }
    }

    protected abstract void Produce();
}
