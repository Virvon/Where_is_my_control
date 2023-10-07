using UnityEngine;
using WhereIsMyControl.Infrastructure;

public class FinishTrigger : MonoBehaviour
{
    private const string ControlFinishPosition = "ControlFinishPosition";

    private Control _control;
    private IGameStateMachine _stateMashine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement playerMovement))
        {
            StopPlayer(playerMovement);
            StopControl();
        }
    }

    public void Init(Control control)
    {
        _control = control;
    }

    private void StopControl() => 
        _control.Stop(GameObject.FindGameObjectWithTag(ControlFinishPosition).transform.position);

    private void StopPlayer(PlayerMovement playerMovement) => 
        playerMovement.Stop();

    private void EnterMenuState()
    {
        
    }
}
