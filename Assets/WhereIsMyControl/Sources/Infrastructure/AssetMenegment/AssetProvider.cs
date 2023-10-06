using UnityEngine;

namespace WhereIsMyControl.Infrastructure
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path, Vector2 position)
        {
            var prefab = Resources.Load<GameObject>(path);

            return Object.Instantiate(prefab, position, Quaternion.identity);
        }

        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);

            return Object.Instantiate(prefab);
        }
    }
}
