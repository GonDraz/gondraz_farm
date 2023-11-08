using Core;
using Core.StateMachine;
using UnityEngine;

namespace Managers
{
    public abstract class BaseStateManager<T> : SingletonMonoBehaviour<T> where T : BaseStateManager<T>
    {
        protected override bool IsDontDestroyOnLoad { get; set; } = true;

        protected readonly StateMachine StateMachine = new();
        
        private void Update()
        {
            StateMachine.Tick();
        }
    }
}