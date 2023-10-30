using System;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using IState = Core.StateMachine.IState;
using StateMachine = Core.StateMachine.StateMachine;

namespace Managers
{
    public abstract class BaseStateManager : MonoBehaviour
    {
        public static BaseStateManager Instance;

        protected StateMachine stateMachineManager = new();
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            } else
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
        }

        protected abstract void Start();

        protected void AddTran(IState from, IState to, Func<bool> cond) => stateMachineManager.AddTransition(from, to, cond);

        private void Update()
        {
            stateMachineManager.Tick();
        }
    }
}