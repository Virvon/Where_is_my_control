using UnityEngine;
using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public interface IGameFactory : IService
    {
        void CreatePlayer(Vector2 position);
    }
}