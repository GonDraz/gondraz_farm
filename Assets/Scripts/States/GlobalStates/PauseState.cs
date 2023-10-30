using Core.StateMachine;
using Managers.StateManagers;

namespace States.GlobalStates
{
    public class PauseState: BaseGlobalState,IState
    {
        public void Tick()
        {
            
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }

        public PauseState(GlobalStateManager globalStateManager) : base(globalStateManager)
        {
        }
    }
}