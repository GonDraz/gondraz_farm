using System;

namespace Core.StateMachine
{
    public abstract class BaseState : IState
    {
        public static bool IsState { get; private set; }
        
        public event Action Enter;
        public event Action Exit;
        
        public virtual void Tick()
        {
        }

        public virtual void OnEnter()
        {
            Enter?.Invoke();
            IsState = true;
        }

        public virtual void OnExit()
        {
            Exit?.Invoke();
            IsState = false;
        }
    }
}