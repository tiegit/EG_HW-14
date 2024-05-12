using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameState _startMenuState;
    [SerializeField] private GameState _actionState;
    [SerializeField] private GameState _cardsState;
    [SerializeField] private GameState _pauseState;
    [SerializeField] private GameState _winState;
    [SerializeField] private GameState _loseState;
    
    private GameState _currentGameState;

    public virtual void Initialize()
    {
        _startMenuState.Initialize(this);
        _actionState?.Initialize(this);
        _cardsState?.Initialize(this);
        _pauseState?.Initialize(this);
        _winState?.Initialize(this);
        _loseState?.Initialize(this);

        SetGameState(_startMenuState);
    }

    public void SetStartMenuState() => SetGameState(_startMenuState);

    public void SetActionState() => SetGameState(_actionState);

    public void SetCardsState() => SetGameState(_cardsState);

    public void SetPauseState() => SetGameState(_pauseState);

    public void SetWinState() => SetGameState(_winState);

    public void SetLoseState() => SetGameState(_loseState);

    private void SetGameState(GameState gameState)
    {
        if (_currentGameState)
        {
            _currentGameState.Exit();
        }

        _currentGameState = gameState;
        gameState.Enter();

        //Debug.Log("Текущий стейт " + _currentGameState);
    }
}
