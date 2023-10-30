using Managers.StateManagers;

namespace States.GlobalStates
{
    public class BaseGlobalState
    {
        protected GlobalStateManager _globalStateManager;

        protected BaseGlobalState(GlobalStateManager globalStateManager)
        {
            _globalStateManager = globalStateManager;
        }
    }
}