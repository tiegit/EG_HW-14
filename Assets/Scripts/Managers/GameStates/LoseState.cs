using System;
using UnityEngine;

public class LoseState : GameState
{
    [SerializeField] private LoseWindow _loseWindow;

    public override void Enter()
    {
        base.Enter();

        Time.timeScale = 0;
        _loseWindow.gameObject.SetActive(true);


    }

    public override void Exit()
    {
        Time.timeScale = 1;
        _loseWindow.gameObject.SetActive(false);
    }
}
