using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WhereIsMyControl.Services
{
    public class SceneLoader : ISceneLoader
    {
        AsyncOperation _waitNextScene;

        public void Load(string scene, Action callback = null)
        {
            if (SceneManager.GetActiveScene().name == scene)
            {
                callback?.Invoke();

                return;
            }

            _waitNextScene = SceneManager.LoadSceneAsync(scene);

            _waitNextScene.completed += _ => callback?.Invoke();
        }

    }
}
