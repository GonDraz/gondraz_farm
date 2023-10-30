using Core.StateMachine;
using Managers.StateManagers;
using UnityEngine;

namespace States.GlobalStates
{
    public class PreLoaderState : BaseGlobalState,IState
    {
        public void Tick()
        {
        }

        public void OnEnter()
        {
            Debug.LogWarning("PreLoaderState OnEnter");
        }

        public void OnExit()
        {
        }

        public PreLoaderState(GlobalStateManager globalStateManager) : base(globalStateManager)
        {
        }
    }
}