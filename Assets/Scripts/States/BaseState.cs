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

        public abstract void Tick();

        public abstract void OnEnter();

        public abstract void OnExit();
    }
}