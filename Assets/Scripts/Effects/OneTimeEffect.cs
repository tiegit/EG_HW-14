public abstract class OneTimeEffect : Effect
{
    public override void Activate()
    {
        base.Activate();
        ApplyEffect();
    }

    protected abstract void ApplyEffect();
}
