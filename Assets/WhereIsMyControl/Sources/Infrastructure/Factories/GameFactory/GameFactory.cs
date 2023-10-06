using UnityEngine;

namespace WhereIsMyControl.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void CreatePlayer(Vector2 position)
        {
            _assetProvider.Instantiate(AssetPath.Player, position);
        }
    }
}
