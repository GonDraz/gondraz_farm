using States;

namespace Managers.StateManagers
{
    public class GlobalStateManager :  BaseStateManager<GlobalStateManager>
    {
        public bool ApplicationLoadFinished { get; set; }
        public bool GamePlay { get; set; }
        public bool GamePause { get; set; }

        public GlobalStates.PreLoaderState PreLoaderState = new();
        public GlobalStates.MenuState MenuState = new();
        public GlobalStates.InGameState InGameState = new();
        public GlobalStates.PauseState PauseState = new();

        protected override void OnInit()
        {
            base.OnInit();
            StateMachine.AddTransition(PreLoaderState, MenuState, () => ApplicationLoadFinished);
            StateMachine.AddTransition(MenuState, InGameState, () => GamePlay);
            StateMachine.AddTransition(InGameState, PauseState, () => GamePause);
            StateMachine.AddTransition(PauseState, InGameState, () => !GamePause);

            StateMachine.SetState(PreLoaderState);
        }
    }
}