using Core.StateMachine;
using UnityEngine;

namespace Managers
{
    public abstract class BaseStateManager<T> : MonoBehaviour where T : BaseStateManager<T>
    {
        protected readonly StateMachine StateMachine = new();

        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;
                DontDestroyOnLoad(gameObject);
                OnInit();
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        protected abstract void OnInit();


        private void Update()
        {
            StateMachine.Tick();
        }

    }
}