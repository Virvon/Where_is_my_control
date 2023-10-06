using UnityEngine;
using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path, Vector2 position);
    }
}