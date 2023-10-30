using Core.StateMachine;
using Managers.StateManagers;

namespace States.GlobalStates
{
    public class InGameState : BaseGlobalState, IState
    {
        public InGameState(GlobalStateManager globalStateManager) : base(globalStateManager)
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