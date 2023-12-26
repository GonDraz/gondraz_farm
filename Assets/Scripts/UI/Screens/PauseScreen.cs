using Managers.StateManagers;

namespace UI.Screens
{
    public class PauseScreen : Screen
    {
        public override void Subscribe()
        {
            GlobalStateManager.PauseState.Enter += Show;
            GlobalStateManager.PauseState.Exit += Hide;
        }

        public override void Unsubscribe()
        {
            GlobalStateManager.PauseState.Enter -= Show;
            GlobalStateManager.PauseState.Exit -= Hide;
        }
    }
}