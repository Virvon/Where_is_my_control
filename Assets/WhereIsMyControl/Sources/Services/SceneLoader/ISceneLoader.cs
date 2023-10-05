using System;

namespace WhereIsMyControl.Services
{
    public interface ISceneLoader : IService
    {
        void Load(string scene, Action callback = null);
    }
}