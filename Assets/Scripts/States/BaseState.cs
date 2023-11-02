using Core.StateMachine;

namespace States
{
    public abstract class BaseState<T> : IState
    {
        protected T StateManager;

        protected BaseState(T stateManager)
        {
            StateManager = stateManager;
        }

        public virtual void Tick()
        {
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}