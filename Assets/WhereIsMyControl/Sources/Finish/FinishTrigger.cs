using System.Collections;
using UnityEngine;
using WhereIsMyControl.Infrastructure;
using WhereIsMyControl.Services;

public class FinishTrigger : MonoBehaviour
{
    private const string ControlFinishPosition = "ControlFinishPosition";
    private const string MenuScene = "Menu";
    private const float WaitingTime = 3;

    private Control _control;
    private IGameStateMachine _stateMashine;
    private ISceneLoader _sceneLoader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement playerMovement))
        {
            StopPlayer(playerMovement);
            StopControl();

            StartCoroutine(Waiter());
        }
    }

    public void Init(Control control)
    {
        _control = control;
    }

    public void Init(ISceneLoader sceneLoader, IGameStateMachine stateMachine)
    {
        _sceneLoader = sceneLoader;
        _stateMashine = stateMachine;
    }

    private void StopControl() => 
        _control.Stop(GameObject.FindGameObjectWithTag(ControlFinishPosition).transform.position);

    private void StopPlayer(PlayerMovement playerMovement) => 
        playerMovement.Stop();

    private void EnterMenuState()
    {
        _sceneLoader.Load(MenuScene, _stateMashine.Enter<MenuState>);
    }

    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(WaitingTime);

        EnterMenuState();
    }
}
