using System;
using Autodesk.Fbx;
using Entity.Player;
using Managers.StateManagers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class ControlManager : MonoBehaviour
    {
        public static ControlManager Instance { get; set; }
        
        private GonDrazFarmControl _control;

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(this);
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        public void Start()
        {
            _control.Player.Move.performed += Move;
        }

        public void Move(InputAction.CallbackContext context)
        {
            PlayerController.movement = context.ReadValue<Vector2>();
        }
    }
}