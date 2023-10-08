using UnityEngine;
using WhereIsMyControl.Infrastructure;
using WhereIsMyControl.Services;

public class AllCutScenesEnded : MonoBehaviour
{
    private const string Level = "Level1";

    public void LoadGameScene()
    {
        AllServices.Instance.Single<IGameStateMachine>().Enter<LoadLevelState, string>(Level);
    }
}
