using Core.StateMachine;
using Managers.StateManagers;
using UnityEngine;

namespace States.GlobalStates
{
    public class PreLoaderState : BaseState<GlobalStateManager>, IState
    {
        public PreLoaderState(GlobalStateManager globalStateManager) : base(globalStateManager)
        {
        }

        public override void Tick()
        {
        }

        public override void OnEnter()
        {
            StateManager.playerController.Controlled = false;
        }

        public override void OnExit()
        {
        }
    }
}