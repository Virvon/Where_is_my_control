using System;

namespace WhereIsMyControl.Services
{
    public interface IInputService : IService
    {
        event Action Jumped;
    }
}