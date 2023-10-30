
using Core.StateMachine;
using Managers.StateManagers;
using UnityEngine;

namespace States.GlobalStates
{
    public class MenuState :  BaseGlobalState,IState
    {
        public MenuState(GlobalStateManager globalStateManager) : base(globalStateManager)
        {
            
        }
        
        public void Tick()
        {
        }

        public void OnEnter()
        {            Debug.LogWarning("MenuState OnEnter");
            _globalStateManager.Dispose();
        }

        public void OnExit()
        {
        }

    }
}