using Core.StateMachine;
using Managers.StateManagers;

namespace States.GlobalStates
{
    public class InGameState : BaseGlobalState,IState
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

        public InGameState(GlobalStateManager globalStateManager) : base(globalStateManager)
        {
        }
    }
}