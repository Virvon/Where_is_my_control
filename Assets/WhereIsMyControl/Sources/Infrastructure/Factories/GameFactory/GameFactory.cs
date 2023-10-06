using UnityEngine;
using WhereIsMyControl.Services;
using Cinemachine;

namespace WhereIsMyControl.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInputService _input;

        private GameObject _playerObject;

        public GameFactory(IAssetProvider assetProvider, IInputService input)
        {
            _assetProvider = assetProvider;
            _input = input;
        }

        public void CreatePlayer(Vector2 position)
        {
            _playerObject = _assetProvider.Instantiate(AssetPath.Player, position);

            _playerObject.GetComponent<PlayerMovement>()
                .Init(_input);
        }

        public void CreateCamera()
        {
            GameObject camera = _assetProvider.Instantiate(AssetPath.Camera);

            camera.GetComponent<CinemachineVirtualCamera>()
                .Follow = _playerObject.transform;
        }

        public void CreateBackground()
        {
            GameObject background = _assetProvider.Instantiate(AssetPath.Background);

            foreach (var parallax in background.GetComponentsInChildren<Parallax>())
                parallax.Init(_playerObject.transform);
        }
    }
}
