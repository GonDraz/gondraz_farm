using Core.StateMachine;
using Managers.StateManagers;
using UnityEngine;

namespace States.GlobalStates
{
    public class MenuState : BaseState<GlobalStateManager>, IState
    {
        public MenuState(GlobalStateManager stateManager) : base(stateManager)
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