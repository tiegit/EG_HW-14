using UnityEngine;
using UnityEngine.UI;

public class StartMenuState : GameState
{
    [SerializeField] private GameObject _startMenuObject;
    [SerializeField] private Button _tapToStartButton;

    public override void Initialize(GameStateManager gameStateManager)
    {
        base.Initialize(gameStateManager);
        _tapToStartButton.onClick.AddListener(_gameStateManager.SetActionState);
    }

    public override void Enter()
    {
        base.Enter();
        _startMenuObject.SetActive(true);
    }

    public override void Exit()
    {
        _startMenuObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _tapToStartButton.onClick.RemoveListener(_gameStateManager.SetActionState);

    }
}
