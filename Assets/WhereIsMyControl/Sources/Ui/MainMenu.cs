using UnityEngine;
using WhereIsMyControl.Infrastructure;

public class MainMenu : MonoBehaviour
{
    private const string Level1 = "Level1";

    private IGameStateMachine _stateMachine;

    public void Init(IGameStateMachine stateMachine)
    {
        _stateMachine = stateMachine; 
    }

    public void Restart()
    {
        _stateMachine.Enter<LoadLevelState, string>(Level1);
    }
}