using UnityEngine;

public abstract class Effect : ScriptableObject
{
    protected EffectsManager _effectsManager;
    protected EnemyManager _enemyManager;
    protected Player _player;

    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField, TextArea(1, 3)] public string Description { get; protected set; }
    [field: SerializeField] public Sprite Sprite { get; protected set; }
    [field: SerializeField] public int Level { get; protected set; } = -1;

    public void Initialize(EffectsManager effectsManager, EnemyManager enemyManager, Player player)
    {
        _effectsManager = effectsManager;
        _enemyManager = enemyManager;
        _player = player;
    }

    public virtual void Activate()
    {
        Level++;
    }
}
