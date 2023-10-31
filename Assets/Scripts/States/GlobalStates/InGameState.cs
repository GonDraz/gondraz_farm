using Core.StateMachine;
using Managers.StateManagers;

namespace States.GlobalStates
{
    public class InGameState : BaseState<GlobalStateManager>, IState
    {
        public InGameState(GlobalStateManager globalStateManager) : base(globalStateManager)
        {
        }

        public override void Tick()
        {
        }

        public override void OnEnter()
        {            
            StateManager.playerController.Controlled = true;

        }

        public override void OnExit()
        {
        }
    }
}