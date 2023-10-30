using Core.StateMachine;
using Managers.StateManagers;

namespace States.GlobalStates
{
    public class PauseState : BaseGlobalState, IState
    {
        public PauseState(GlobalStateManager globalStateManager) : base(globalStateManager)
        {
        }

        public void Tick()
        {
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }
    }
}