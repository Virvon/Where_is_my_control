using UnityEngine;
using WhereIsMyControl.Infrastructure;

public class ControlSpawnTrigger : MonoBehaviour
{
    private IGameFactory _factory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player))
            Spawn();
    }

    public void Init(IGameFactory facotry)
    {
        _factory = facotry;
    }

    private void Spawn() => 
        _factory.CreateControl();
}
