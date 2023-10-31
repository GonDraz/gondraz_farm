using Core.StateMachine;
using Managers.StateManagers;

namespace States.GlobalStates
{
    public class PauseState : BaseState<GlobalStateManager>, IState
    {
        public PauseState(GlobalStateManager globalStateManager) : base(globalStateManager)
        {
        }

        public override void Tick()
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
        }
    }
}