using System;
using Core.StateMachine;
using UnityEngine;

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
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
        }

        protected abstract void Start();

        private void Update()
        {
            stateMachineManager.Tick();
        }

        protected void AddTran(IState from, IState to, Func<bool> cond)
        {
            stateMachineManager.AddTransition(from, to, cond);
        }
    }
}