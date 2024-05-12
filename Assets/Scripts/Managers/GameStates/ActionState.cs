using UnityEngine;

public class ActionState : GameState
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private RigidbodyMove _rigidbodyMove;

    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private ExperienceManager _experienceManager;

    public override void EnterFirstTime()
    {
        _enemyManager.StartNewWave(0);
        _experienceManager.UpLevel();
    }

    public override void Enter()
    {
        base.Enter();
        //_joystick.Activate();
        //_rigidbodyMove.enabled = true;
        _rigidbodyMove.SetActionStateAvailability(true);
    }

    public override void Exit()
    {
        _rigidbodyMove.SetActionStateAvailability(false);
        //_joystick.Deactivate();
        //_rigidbodyMove.enabled = false;
    }
}
