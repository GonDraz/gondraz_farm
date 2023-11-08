using Core;
using Entity.Player;
using Managers.StateManagers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class ControlManager : SingletonMonoBehaviour<ControlManager>
    {
        protected override bool IsDontDestroyOnLoad { get; set; } = true;
        protected override void OnInit()
        {            
            base.OnInit();
            GlobalStateManager.Instance.InGameState.Enter += OnInGameEnter;
            GlobalStateManager.Instance.InGameState.Exit += OnInGameExit;
        }
        
        private GonDrazFarmControl _control;

        private void Start()
        {
            _control = new GonDrazFarmControl();
            _control.Enable();
        }

        private void OnInGameEnter()
        {
            _control.Player.Enable();

            _control.Player.Move.performed += PlayerController.Instance.Move;
            _control.Player.Move.canceled += PlayerController.Instance.Move;
        }



        private void OnInGameExit()
        {
        }
    }
}