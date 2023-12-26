using Core;
using Entity.Player;
using Managers.StateManagers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class ControlManager : SingletonMonoBehaviour<ControlManager>
    {
        protected override bool IsDontDestroyOnLoad()
        {
            return true;
        }
        
        private GonDrazFarmControl _control;
        private GonDrazFarmControl.PlayerActions _playerControl;
        private GonDrazFarmControl.UIActions _uiControl;

        protected override void OnInit()
        {            
            base.OnInit();
            _control = new GonDrazFarmControl();
            _control.Enable();

            _playerControl = _control.Player;
            _uiControl = _control.UI;
        }

        public override void Subscribe()
        {
            base.Subscribe();
            GlobalStateManager.InGameState.Enter += InGameStateOnEnter;
            GlobalStateManager.InGameState.Exit += InGameStateOnExit;
        }
        private void InGameStateOnEnter()
        {
            _control.Player.Move.performed += PlayerController.Instance.Move;
            _control.Player.Move.canceled += PlayerController.Instance.Move;

            _control.Player.Fire.performed += PlayerController.Instance.Fire;

            _control.Player.Run.performed += PlayerController.Instance.Run;
            _control.Player.Run.canceled += PlayerController.Instance.Run;
            
            _control.UI.Cancel.performed += OnCancel;
        }
        
        private void InGameStateOnExit()
        {
            _control.Player.Move.performed -= PlayerController.Instance.Move;
            _control.Player.Move.canceled -= PlayerController.Instance.Move;

            _control.Player.Fire.performed -= PlayerController.Instance.Fire;

            _control.Player.Run.performed -= PlayerController.Instance.Run;
            _control.Player.Run.canceled -= PlayerController.Instance.Run;
            
            _control.UI.Cancel.performed -= OnCancel;
        }


        private void OnCancel(InputAction.CallbackContext obj)
        {
            GlobalStateManager.GamePause = !GlobalStateManager.GamePause;
        }
    }
}