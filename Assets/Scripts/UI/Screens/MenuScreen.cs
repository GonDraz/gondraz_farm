using Managers.StateManagers;

namespace UI.Screens
{
    public class MenuScreen : Screen
    {
        public override void Subscribe()
        {
            GlobalStateManager.MenuState.Enter += Show;
            GlobalStateManager.MenuState.Exit += Hide;
        }

        public override void Unsubscribe()
        {
            GlobalStateManager.MenuState.Enter -= Show;
            GlobalStateManager.MenuState.Exit -= Hide;
        }
    }
}