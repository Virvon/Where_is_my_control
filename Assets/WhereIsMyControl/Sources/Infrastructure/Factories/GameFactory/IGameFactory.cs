using UnityEngine;
using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector2 position);
        void CreateCamera();
        void CreateBackground();
        void CreateDeathMenu();
        void CreateControl();
        void CreateMainMenu();
        void CreateControlSpawnTrigger(Vector2 position);
        void CreateFinishTrigger(Vector2 position);
    }
}