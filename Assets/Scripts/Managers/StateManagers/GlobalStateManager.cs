using System;
using Entity.Player;
using States.GlobalStates;
using UnityEngine;

namespace Managers.StateManagers
{
    public class GlobalStateManager : BaseStateManager<GlobalStateManager>
    {
        public PlayerController playerController;        
        // public 
        
        public bool ApplicationLoadFinished { get; set; }
        public bool GamePlay { get; set; }
        public bool GamePause { get; set; }

        protected override void OnInit()
        {
            var preLoaderState = new PreLoaderState(this);
            var menuState = new MenuState(this);
            var inGameState = new InGameState(this);
            var pauseState = new PauseState(this);

            StateMachine.AddTransition(preLoaderState, menuState, () => ApplicationLoadFinished);
            StateMachine.AddTransition(menuState, inGameState, () => GamePlay);
            StateMachine.AddTransition(inGameState, pauseState, () => GamePause);
            StateMachine.AddTransition(pauseState, inGameState, () => !GamePause);

            StateMachine.SetState(preLoaderState);
        }

        private void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
        }
    }
}