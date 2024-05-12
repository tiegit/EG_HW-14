using UnityEngine;
public class CardsState : GameState
{
    public override void Enter()
    {
        base.Enter();
        Time.timeScale = 0;
    }

    public override void Exit()
    {
        Time.timeScale = 1;
    }
}
