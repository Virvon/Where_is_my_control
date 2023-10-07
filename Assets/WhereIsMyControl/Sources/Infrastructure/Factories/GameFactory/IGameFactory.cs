using UnityEngine;
using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public interface IGameFactory : IService
    {
        void CreatePlayer(Vector2 position);
        void CreateCamera();
        void CreateBackground();
        void CreateGameOverMenu();
        void CreateDeathMenu();
    }
}