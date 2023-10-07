using UnityEngine;
using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector2 position);
        void CreateCamera();
        void CreateBackground();
        void CreateGameOverMenu();
        void CreateDeathMenu();
        void CreateControl();
        void CreateControlSpawnTrigger(Vector2 position);
    }
}