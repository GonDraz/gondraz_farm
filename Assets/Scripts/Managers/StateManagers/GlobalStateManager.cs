using States;

namespace Managers.StateManagers
{
    public class GlobalStateManager : BaseStateManager
    {
        public static GlobalStates.PreLoaderState PreLoaderState = new();
        public static GlobalStates.MenuState MenuState = new();
        public static GlobalStates.InGameState InGameState = new();
        public static GlobalStates.PauseState PauseState = new();
        public static bool ApplicationLoadFinished { get; set; }
        public static bool GamePlay { get; set; }
        public static bool GamePause { get; set; }

        protected void Awake()
        {
            StateMachine.AddTransition(PreLoaderState, MenuState, () => ApplicationLoadFinished);
            StateMachine.AddTransition(MenuState, InGameState, () => GamePlay);
            StateMachine.AddTransition(InGameState, PauseState, () => GamePause);
            StateMachine.AddTransition(PauseState, InGameState, () => !GamePause);

            StateMachine.SetState(PreLoaderState);
        }
    }
}