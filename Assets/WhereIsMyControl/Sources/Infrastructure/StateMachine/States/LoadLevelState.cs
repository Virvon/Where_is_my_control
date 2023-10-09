using UnityEngine;
using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public class LoadLevelState : IPayloadState<string>
    {
        private const string StartPoint = "StartPoint";
        private const string FinishPoint = "FinishPoint";
        private const string ControlSpawnTrigger = "ControlSpawnTrigger";

        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFacotry;

        public LoadLevelState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, IGameFactory gameFacotry)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFacotry = gameFacotry;
        }


        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, OnLoaded);
        }

        private void OnLoaded()
        {
            _gameFacotry.CreateDeathMenu();
            _gameFacotry.CreatePlayer(GameObject.FindGameObjectWithTag(StartPoint).transform.position);
            _gameFacotry.CreateCamera();
            _gameFacotry.CreateBackground();
            _gameFacotry.CreateControlSpawnTrigger(GameObject.FindGameObjectWithTag(ControlSpawnTrigger).transform.position);
            _gameFacotry.CreateFinishTrigger(GameObject.FindGameObjectWithTag(FinishPoint).transform.position);
            _gameFacotry.CreatePause();

            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }
    }
}